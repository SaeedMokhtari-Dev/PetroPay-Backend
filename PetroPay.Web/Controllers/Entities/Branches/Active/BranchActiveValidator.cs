using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Active
{
    public class BranchActiveValidator : AbstractValidator<BranchActiveRequest>
    {
        public BranchActiveValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
        }
    }
}
