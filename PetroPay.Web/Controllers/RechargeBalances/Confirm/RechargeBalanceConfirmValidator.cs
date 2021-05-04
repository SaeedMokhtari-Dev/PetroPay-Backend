using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.RechargeBalances.Confirm
{
    public class RechargeBalanceConfirmValidator : AbstractValidator<RechargeBalanceConfirmRequest>
    {
        public RechargeBalanceConfirmValidator()
        {
            RuleFor(x => x.RechargeId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.IdRequired);
        }
    }
}
