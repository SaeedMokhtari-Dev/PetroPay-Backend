using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Branches.Get
{
    public class BranchGetValidator : AbstractValidator<BranchGetRequest>
    {
        public BranchGetValidator()
        {
            RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.BranchMessage.CompanyIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
