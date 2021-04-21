using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Branches.Delete
{
    public class BranchDeleteValidator : AbstractValidator<BranchDeleteRequest>
    {
        public BranchDeleteValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
        }
    }
}
