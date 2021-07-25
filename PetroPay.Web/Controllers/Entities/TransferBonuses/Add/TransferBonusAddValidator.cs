using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Add
{
    public class TransferBonusAddValidator : AbstractValidator<TransferBonusAddRequest>
    {
        public TransferBonusAddValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ApiMessages.TransferBonusMessage.AmountRequired);
        }
    }
}
