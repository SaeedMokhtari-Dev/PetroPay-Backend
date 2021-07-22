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

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Get
{
    public class SubscriptionGetHandler : ApiRequestHandler<SubscriptionGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public SubscriptionGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(SubscriptionGetRequest request)
        {
            if (!request.CompanyId.HasValue && _userContext.Role != RoleType.Admin)
                request.CompanyId = _userContext.Id;
            
            var query = _context.Subscriptions.Include(w => w.Company)
                .OrderByDescending(w => w.SubscriptionDate)
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
            
            SubscriptionGetResponse response = new SubscriptionGetResponse();
            response.TotalCount = await query.CountAsync();
            
            query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<SubscriptionGetResponseItem>>(result);

            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<Subscription> createQuery(IQueryable<Subscription> query, SubscriptionGetRequest request)
        {
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.SubscriptionDate.HasValue && w.SubscriptionDate.Value >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.SubscriptionDate.HasValue && w.SubscriptionDate.Value <= dateTimeTo);
            }
            if (request.Status.HasValue)
            {
                switch (request.Status.Value)
                {
                    case 1: //Active
                        query = query.Where(w => w.SubscriptionActive == true);
                        break;
                    case 2: //Reject
                        query = query.Where(w => w.Rejected == true);
                        break;
                    case 3: //Pending
                        query = query.Where(w =>
                            ((!w.SubscriptionActive.HasValue) || w.SubscriptionActive == false) &&
                            ((!w.Rejected.HasValue) || w.Rejected == false));
                        break;
                }
            }
            return query;

        }
    }
}
