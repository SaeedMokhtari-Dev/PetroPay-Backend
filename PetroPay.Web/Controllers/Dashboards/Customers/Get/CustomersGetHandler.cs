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

namespace PetroPay.Web.Controllers.Dashboards.Customers.Get
{
    public class CustomerGetHandler : ApiRequestHandler<CustomerGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CustomerGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CustomerGetRequest request)
        {
            if(_userContext.Role != RoleType.Customer)
                return ActionResult.Error(ApiMessages.Forbidden);

            var company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == request.CompanyId);
            
            if(company == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            CustomerGetResponse response = new CustomerGetResponse();
            response.TotalCustomerBalance = company.CompanyBalnce ?? 0;
            response.TotalCarBalance = await _context.Cars.Include(w => w.CompanyBarnch)
                .Where(w => w.CompanyBarnch.CompanyId.HasValue && w.CompanyBarnch.CompanyId.Value == request.CompanyId)
                .SumAsync(w => w.CarBalnce ?? 0);

            response.CompanyBranchItems = await _context.CompanyBranches.Where(w => w.CompanyId == request.CompanyId)
                .Select(w => new CompanyBranchItem()
                {
                    Key = w.CompanyBranchId,
                    BranchName = w.CompanyBranchName,
                    BranchBalance = w.CompanyBranchBalnce ?? 0
                }).ToListAsync();
            
            response.CompanySubscriptionItems = await _context.Subscriptions.Where(w => w.CompanyId == request.CompanyId)
                .Select(w => new CompanySubscriptionItem()
                {
                    Key = w.SubscriptionId,
                    StartDate = (w.SubscriptionStartDate ?? DateTime.Now).ToString(DateTimeConstants.DateFormat),
                    EndDate = (w.SubscriptionEndDate ?? DateTime.Now).ToString(DateTimeConstants.DateFormat)
                }).ToListAsync();
            
            
            return ActionResult.Ok(response);
        }
    }
}
