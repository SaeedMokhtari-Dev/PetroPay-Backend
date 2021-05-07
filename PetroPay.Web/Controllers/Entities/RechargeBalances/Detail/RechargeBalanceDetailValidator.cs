using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Detail
{
    public class RechargeBalanceDetailValidator : AbstractValidator<RechargeBalanceDetailRequest>
    {
        public RechargeBalanceDetailValidator()
        {
            RuleFor(x => x.RechargeId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.IdRequired);
        }
    }
}
