using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Detail
{
    public class AccountBalanceDetailValidator : AbstractValidator<AccountBalanceDetailRequest>
    {
        public AccountBalanceDetailValidator()
        {
            RuleFor(x => x.AccountBalancesId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
