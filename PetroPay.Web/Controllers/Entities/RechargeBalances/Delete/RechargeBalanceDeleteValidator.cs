using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Delete
{
    public class RechargeBalanceDeleteValidator : AbstractValidator<RechargeBalanceDeleteRequest>
    {
        public RechargeBalanceDeleteValidator()
        {
            RuleFor(x => x.RechargeId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.IdRequired);
        }
    }
}
