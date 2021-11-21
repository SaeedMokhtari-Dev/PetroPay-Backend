using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.Add
{
    public class TransferBalanceAddValidator : AbstractValidator<TransferBalanceAddRequest>
    {
        public TransferBalanceAddValidator()
        {
            RuleFor(x => x.TransferBalanceType).NotEmpty().WithMessage(ApiMessages.TransferBalanceMessage.TransferBalanceTypeRequired);
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ApiMessages.TransferBalanceMessage.AmountRequired);
        }
    }
}
