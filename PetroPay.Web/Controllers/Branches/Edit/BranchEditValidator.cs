using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Branches.Edit
{
    public class BranchEditValidator : AbstractValidator<BranchEditRequest>
    {
        public BranchEditValidator()
        {
            RuleFor(x => x.CompanyBranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.BranchMessage.CompanyIdRequired);
        }
    }
}
