using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Edit
{
    public class BranchEditValidator : AbstractValidator<BranchEditRequest>
    {
        public BranchEditValidator()
        {
            RuleFor(x => x.CompanyBranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.IdRequired);
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.BranchMessage.CompanyIdRequired);
            RuleFor(x => x.CompanyBranchAdminUserPassword).Matches(PasswordConstants.PasswordRegex).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
