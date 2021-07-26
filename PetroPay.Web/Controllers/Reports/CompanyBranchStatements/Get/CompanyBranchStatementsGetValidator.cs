using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get
{
    public class CompanyBranchStatementGetValidator : AbstractValidator<CompanyBranchStatementGetRequest>
    {
        public CompanyBranchStatementGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
