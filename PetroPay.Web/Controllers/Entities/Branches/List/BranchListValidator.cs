using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.List
{
    public class BranchListValidator : AbstractValidator<BranchListRequest>
    {
        public BranchListValidator()
        {
            RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.BranchMessage.CompanyIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
