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
            var query = _context.Subscriptions.Include(w => w.Company)
                .OrderByDescending(w => w.SubscriptionDate)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            if(_userContext.Role == RoleType.Customer && !request.CompanyId.HasValue)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            if(_userContext.Role == RoleType.Supplier)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            if (_userContext.Role == RoleType.Customer && request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId.HasValue && w.CompanyId.Value == request.CompanyId.Value);
            }
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<SubscriptionGetResponseItem>>(result);

            SubscriptionGetResponse response = new SubscriptionGetResponse();
            response.TotalCount = await _context.Subscriptions.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
