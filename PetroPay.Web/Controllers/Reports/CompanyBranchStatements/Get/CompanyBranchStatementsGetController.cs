using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get
{
    [Route(Endpoints.ApiCompanyBranchStatementGet)]
    [ApiExplorerSettings(GroupName = "CompanyBranchStatement")]
    [Authorize]
    public class CompanyBranchStatementGetController : ApiController<CompanyBranchStatementGetRequest>
    {
        public CompanyBranchStatementGetController(IApiRequestHandler<CompanyBranchStatementGetRequest> handler, IValidator<CompanyBranchStatementGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
