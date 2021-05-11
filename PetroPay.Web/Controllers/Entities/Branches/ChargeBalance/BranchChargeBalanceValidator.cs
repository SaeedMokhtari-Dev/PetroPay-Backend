using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.ChargeBalance
{
    public class BranchChargeBalanceValidator : AbstractValidator<BranchChargeBalanceRequest>
    {
        public BranchChargeBalanceValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
            RuleFor(x => x.IncreaseAmount).NotEmpty().WithMessage(ApiMessages.BranchMessage.IncreaseAmountRequired);
        }
    }
}
