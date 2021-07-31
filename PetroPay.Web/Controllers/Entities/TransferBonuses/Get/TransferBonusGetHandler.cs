using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Get
{
    public class TransferBonusGetHandler : ApiRequestHandler<TransferBonusGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;
        
        public TransferBonusGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(TransferBonusGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer)
                return ActionResult.Error(ApiMessages.Forbidden);
            if (!request.StationId.HasValue && _userContext.Role == RoleType.Supplier)
                request.StationId = _userContext.Id;
            
            /*var transferBonuses = await _context.PetropayAccounts.Where(w => w.AccPetrolStationBonus.HasValue && w.AccPetrolStationBonus.Value)
                .Select(w => w.AccountId).ToListAsync();*/
            List<int?> accountIds = new List<int?>();
            if (_userContext.Role == RoleType.Supplier)
            {
                var user = await _context.PetroStations.FindAsync(_userContext.Id); 
                accountIds.Add(user.AccountId);
            }
            else
                accountIds.AddRange(await _context.PetroStations.Where(w => w.AccountId.HasValue).Select(w => w.AccountId).ToListAsync());
            
            var query = _context.TransAccounts.Include(w => w.Account)
                .Where(w => accountIds.Contains(w.AccountId) && w.TransDocument == "petrol station bonus transfer")
                .OrderByDescending(w => w.TransId)
                .AsQueryable();

            //query = createQuery(query, request);

            /*if (request.StationId.HasValue)
                query = query.Where(w => w.UserId.HasValue && w.UserId.Value == request.StationId.Value);*/
            
            TransferBonusGetResponse response = new TransferBonusGetResponse();
            response.TotalCount = await query.CountAsync();
            
           query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
           
           var result = await query.ToListAsync();

           var mappedResult = _mapper.Map<List<TransferBonusGetResponseItem>>(result);

           response.Items = mappedResult;
           return ActionResult.Ok(response);
        }
        /*private IQueryable<TransAccount> createQuery(IQueryable<TransAccount> query, TransferBonusGetRequest request)
        {
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.TransDate.HasValue && w.TransDate.Value >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.TransDate.HasValue && w.TransDate.Value <= dateTimeTo);
            }
            return query;

        }*/
    }
}
