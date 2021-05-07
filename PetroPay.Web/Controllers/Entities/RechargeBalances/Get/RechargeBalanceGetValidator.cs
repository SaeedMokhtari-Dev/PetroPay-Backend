using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    public class RechargeBalanceGetValidator : AbstractValidator<RechargeBalanceGetRequest>
    {
        public RechargeBalanceGetValidator()
        {
            //RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.RechargeBalanceMessage.CompanyIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
