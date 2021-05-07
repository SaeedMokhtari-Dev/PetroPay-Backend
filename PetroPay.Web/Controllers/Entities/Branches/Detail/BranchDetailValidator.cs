using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Detail
{
    public class BranchDetailValidator : AbstractValidator<BranchDetailRequest>
    {
        public BranchDetailValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
        }
    }
}
