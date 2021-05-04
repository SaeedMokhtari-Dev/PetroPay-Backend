using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.RechargeBalances.Edit
{
    public class RechargeBalanceEditValidator : AbstractValidator<RechargeBalanceEditRequest>
    {
        public RechargeBalanceEditValidator()
        {
            RuleFor(x => x.RechargeId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.IdRequired);
        }
    }
}
