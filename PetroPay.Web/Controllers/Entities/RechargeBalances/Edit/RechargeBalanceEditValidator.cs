using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Edit
{
    public class RechargeBalanceEditValidator : AbstractValidator<RechargeBalanceEditRequest>
    {
        public RechargeBalanceEditValidator()
        {
            RuleFor(x => x.RechargeId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.IdRequired);
        }
    }
}
