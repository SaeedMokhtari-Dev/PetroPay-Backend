using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Add
{
    public class RechargeBalanceAddHandler : ApiRequestHandler<RechargeBalanceAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public RechargeBalanceAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceAddRequest request)
        {
            RechargeBalance rechargeBalance = await AddRechargeBalance(request);
            
            return ActionResult.Ok(ApiMessages.RechargeBalanceMessage.AddedSuccessfully);
        }
        
        private async Task<RechargeBalance> AddRechargeBalance(RechargeBalanceAddRequest request)
        {
            RechargeBalance rechargeBalance = await _context.ExecuteTransactionAsync(async () =>
            {
                RechargeBalance newRechargeBalance = _mapper.Map<RechargeBalance>(request);
                
                newRechargeBalance = (await _context.RechargeBalances.AddAsync(newRechargeBalance)).Entity;
                await _context.SaveChangesAsync();

                return newRechargeBalance;
            });
            return rechargeBalance;
        }
    }
}