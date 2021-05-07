using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Delete
{
    public class RechargeBalanceDeleteHandler : ApiRequestHandler<RechargeBalanceDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public RechargeBalanceDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceDeleteRequest request)
        {
            RechargeBalance rechargeBalance = await _context.RechargeBalances
                .FindAsync(request.RechargeId);

            if (rechargeBalance == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.RechargeBalances.Remove(rechargeBalance);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.RechargeBalanceMessage.DeletedSuccessfully);
        }
    }
}
