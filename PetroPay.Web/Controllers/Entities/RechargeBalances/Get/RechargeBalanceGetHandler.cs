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
            var query = _context.RechargeBalances.Include(w => w.Company)
                .OrderByDescending(w => w.RechageDate)
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

            var mappedResult = _mapper.Map<List<RechargeBalanceGetResponseItem>>(result);

            RechargeBalanceGetResponse response = new RechargeBalanceGetResponse();
            response.TotalCount = await _context.RechargeBalances.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
