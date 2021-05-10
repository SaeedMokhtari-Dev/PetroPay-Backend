using System;
using System.Collections.Generic;
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

namespace PetroPay.Web.Controllers.Reports.CarBalances.Get
{
    public class CarBalanceGetHandler : ApiRequestHandler<CarBalanceGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarBalanceGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarBalanceGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);
            
            var query = _context.ViewCarBalances.OrderByDescending(w => w.SubscriptionStartDate)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CarBalanceGetResponse response = new CarBalanceGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumCarBalance = await query.SumAsync(w => w.CarBalnce ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarBalanceGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCarBalance> createQuery(IQueryable<ViewCarBalance> query, CarBalanceGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.CompanyName.Contains(request.CompanyName));
            }
            return query;

        }
    }
}
