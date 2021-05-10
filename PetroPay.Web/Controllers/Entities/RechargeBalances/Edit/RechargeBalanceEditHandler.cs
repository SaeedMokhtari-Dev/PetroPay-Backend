using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Edit
{
    public class RechargeBalanceEditHandler : ApiRequestHandler<RechargeBalanceEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public RechargeBalanceEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceEditRequest request)
        {
            RechargeBalance editRechargeBalance = await _context.RechargeBalances
                .FindAsync(request.RechargeId);

            if (editRechargeBalance == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (editRechargeBalance.RechargeRequstConfirmed.HasValue && editRechargeBalance.RechargeRequstConfirmed.Value)
            {
                return ActionResult.Error(ApiMessages.RechargeBalanceMessage.ConfirmedEntityEditNotAllowed);
            }
            
            await EditRechargeBalance(editRechargeBalance, request);
            return ActionResult.Ok(ApiMessages.RechargeBalanceMessage.EditedSuccessfully);
        }

        private async Task EditRechargeBalance(RechargeBalance editRechargeBalance, RechargeBalanceEditRequest request)
        {
            _mapper.Map(request, editRechargeBalance);

            await _context.SaveChangesAsync();
        }
    }
}