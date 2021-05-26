using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.Add
{
    [Route(Endpoints.ApiCompanyAdd)]
    [ApiExplorerSettings(GroupName = "Company")]
    [Authorize]
    public class CompanyAddController : ApiController<CompanyAddRequest>
    {
        public CompanyAddController(IApiRequestHandler<CompanyAddRequest> handler, IValidator<CompanyAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
