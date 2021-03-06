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
            if(_userContext.Role == RoleType.Customer || _userContext.Role == RoleType.CustomerBranch)
                return ActionResult.Error(ApiMessages.Forbidden);
            if (!request.CompanyId.HasValue && _userContext.Role == RoleType.Supplier)
                request.CompanyId = _userContext.Id;
            if (!request.StationId.HasValue && _userContext.Role == RoleType.SupplierBranch)
                request.StationId = _userContext.Id;
            
            /*var transferBonuses = await _context.PetropayAccounts.Where(w => w.AccPetrolStationBonus.HasValue && w.AccPetrolStationBonus.Value)
                .Select(w => w.AccountId).ToListAsync();*/
            List<int> accountIds = new List<int>();
            switch (_userContext.Role)
            {
                case RoleType.Supplier:
                {
                    var stationAccountIds = await _context.PetroStations.Where(w => w.PetrolCompanyId.HasValue && w.PetrolCompanyId.Value == request.CompanyId.Value && w.AccountId.HasValue).Select(w => w.AccountId.Value).ToListAsync(); 
                    accountIds.AddRange(stationAccountIds);
                    break;
                }
                case RoleType.SupplierBranch:
                {
                    var user = await _context.PetroStations.FindAsync(request.StationId); 
                    accountIds.Add(user.AccountId ?? 0);
                    break;
                }
                case RoleType.Admin:
                    accountIds.AddRange(await _context.PetroStations.Where(w => w.AccountId.HasValue).Select(w => w.AccountId.Value).ToListAsync());
                    break;
            }
            
            var query = _context.TransAccounts.Include(w => w.Account)
                .Where(w => w.AccountId.HasValue && accountIds.Contains(w.AccountId.Value) && w.TransDocument == "petrol station bonus transfer")
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
