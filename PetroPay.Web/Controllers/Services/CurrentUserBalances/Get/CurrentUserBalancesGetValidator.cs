using FluentValidation;

namespace PetroPay.Web.Controllers.Services.CurrentUserBalances.Get
{
    public class CurrentUserBalanceGetValidator : AbstractValidator<CurrentUserBalanceGetRequest>
    {
        public CurrentUserBalanceGetValidator()
        {
        }
    }
}
