using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Companies.Add
{
    [Route(Endpoints.ApiCompanyAdd)]
    [ApiExplorerSettings(GroupName = "Company")]
    public class CompanyAddController : ApiController<CompanyAddRequest>
    {
        public CompanyAddController(IApiRequestHandler<CompanyAddRequest> handler, IValidator<CompanyAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
