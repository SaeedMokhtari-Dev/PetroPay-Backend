using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.List
{
    [Route(Endpoints.ApiCompanyList)]
    [ApiExplorerSettings(GroupName = "Company")]
    [Authorize]
    public class CompanyListController : ApiController<CompanyListRequest>
    {
        public CompanyListController(IApiRequestHandler<CompanyListRequest> handler, IValidator<CompanyListRequest> validator) : base(handler, validator)
        {
        }
    }
}
