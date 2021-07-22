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

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    public class RechargeBalanceGetHandler : ApiRequestHandler<RechargeBalanceGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public RechargeBalanceGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceGetRequest request)
        {
            if (!request.CompanyId.HasValue && _userContext.Role != RoleType.Admin)
                request.CompanyId = _userContext.Id;
            
            var query = _context.RechargeBalances.Include(w => w.Company)
                .OrderByDescending(w => w.RechageDate)
                .AsQueryable();

            if(_userContext.Role == RoleType.Customer && !request.CompanyId.HasValue)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            if(_userContext.Role == RoleType.Supplier)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            if (_userContext.Role == RoleType.Customer && request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId.HasValue && w.CompanyId.Value == request.CompanyId.Value);
            }
            query = createQuery(query, request);
            
            RechargeBalanceGetResponse response = new RechargeBalanceGetResponse();
            response.TotalCount = await query.CountAsync();
            
            query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<RechargeBalanceGetResponseItem>>(result);

            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<RechargeBalance> createQuery(IQueryable<RechargeBalance> query, RechargeBalanceGetRequest request)
        {
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.RechageDate.HasValue && w.RechageDate.Value  >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.RechageDate.HasValue && w.RechageDate.Value <= dateTimeTo);
            }
            if (request.Status.HasValue)
            {
                switch (request.Status.Value)
                {
                    case 1: //Confirmed
                        query = query.Where(w => w.RechargeRequstConfirmed.HasValue && w.RechargeRequstConfirmed == true);
                        break;
                    case 2: //NotConfirmed
                        query = query.Where(w => w.RechargeRequstConfirmed == null || w.RechargeRequstConfirmed == false);
                        break;
                }
            }
            return query;

        }
    }
}
