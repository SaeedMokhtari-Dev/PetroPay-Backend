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
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Dashboards.Admin.Get
{
    public class AdminGetHandler : ApiRequestHandler<AdminGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public AdminGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(AdminGetRequest request)
        {
            if(_userContext.Role != RoleType.Admin)
                return ActionResult.Error(ApiMessages.Forbidden);

            AdminGetResponse response = new AdminGetResponse();
            
            response.RechargeRequests = await _context.RechargeBalances
                .Where(w => (!w.RechargeRequstConfirmed.HasValue) || w.RechargeRequstConfirmed == false).CountAsync();

            response.CarRequests = await _context.Cars
                .Where(w => (!w.CarWorkWithApproval.HasValue) || w.CarWorkWithApproval == false).CountAsync();
            
            response.SubscriptionRequests = await _context.Subscriptions
                .Where(w => (!w.SubscriptionActive.HasValue) || w.SubscriptionActive == false).CountAsync();

            var companies = await _context.Companies.Select(w => new
            {
                w.CompanyId, w.CompanyName, w.CompanyBalnce
            }).ToListAsync();
            foreach (var company in companies)
            {
                decimal branchesBalance = await _context.CompanyBranches.Where(
                    w => w.CompanyId.HasValue && w.CompanyId.Value == company.CompanyId).SumAsync(w => w.CompanyBranchBalnce ?? 0);
                decimal carsBalance = await _context.Cars.Include(w => w.CompanyBarnch).Where(
                    w => w.CompanyBarnchId.HasValue && w.CompanyBarnch.CompanyId.HasValue && w.CompanyBarnch.CompanyId.Value == company.CompanyId)
                    .SumAsync(w => w.CarBalnce ?? 0);
                
                CompanyListItem companyItem = new CompanyListItem();
                companyItem.Key = company.CompanyId;
                companyItem.Name = company.CompanyName;
                companyItem.Balance = (company.CompanyBalnce ?? 0) + branchesBalance + carsBalance;
                response.CompanyListItems.Add(companyItem);
            }
            
            response.PetrolStationItems = await _context.PetroStations.Select(w => new PetrolStationItem()
            {
                Key = w.StationId,
                Name = w.StationName,
                Balance =  w.StationBalance ?? 0
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
