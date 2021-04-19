using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Companies.Get
{
    [Route(Endpoints.ApiCompanyGet)]
    [ApiExplorerSettings(GroupName = "Company")]
    public class CompanyGetController : ApiController<CompanyGetRequest>
    {
        public CompanyGetController(IApiRequestHandler<CompanyGetRequest> handler, IValidator<CompanyGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
