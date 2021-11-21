using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.CarBatch
{
    public class TransferBalanceCarBatchValidator : AbstractValidator<TransferBalanceCarBatchRequest>
    {
        public TransferBalanceCarBatchValidator()
        {
            RuleFor(x => x.CarAmounts).NotEmpty().WithMessage(ApiMessages.TransferBalanceMessage.CarIdsRequired);
            RuleForEach(x => x.CarAmounts).ChildRules(orders => 
            {
                orders.RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ApiMessages.TransferBalanceMessage.AmountRequired);
                orders.RuleFor(x => x.CarId).GreaterThan(0).WithMessage(ApiMessages.TransferBalanceMessage.CarIdsRequired);
            });
            RuleFor(x => x.BranchId).GreaterThan(0).WithMessage(ApiMessages.TransferBalanceMessage.BranchIdRequired);
        }
    }
}
