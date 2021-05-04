using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.RechargeBalances.Detail
{
    public class RechargeBalanceDetailHandler : ApiRequestHandler<RechargeBalanceDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public RechargeBalanceDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceDetailRequest request)
        {
            RechargeBalance rechargeBalance = await _context.RechargeBalances
                .FindAsync(request.RechargeId);

            if (rechargeBalance == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            RechargeBalanceDetailResponse response = _mapper.Map<RechargeBalanceDetailResponse>(rechargeBalance);
            
            return ActionResult.Ok(response);
        }
    }
}
