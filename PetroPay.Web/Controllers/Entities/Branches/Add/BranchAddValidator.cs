using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Add
{
    public class BranchAddValidator : AbstractValidator<BranchAddRequest>
    {
        public BranchAddValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.BranchMessage.CompanyIdRequired);
            RuleFor(x => x.CompanyBranchAdminUserPassword).Matches(PasswordConstants.PasswordRegex).WithMessage(ApiMessages.MinPasswordLengthError);
            /*RuleFor(x => x.AuditingBranchId).NotEmpty().WithMessage(ApiMessages.BranchMessage.AuditingBranchIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.BranchMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.BranchMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.BranchMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.BranchMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.BranchMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.BranchMessage.FunctionRequired);*/
            
        }
    }
}
