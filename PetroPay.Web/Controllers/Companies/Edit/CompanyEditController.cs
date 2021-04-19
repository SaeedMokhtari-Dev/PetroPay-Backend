using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Companies.Edit
{
    [Route(Endpoints.ApiCompanyEdit)]
    [ApiExplorerSettings(GroupName = "Company")]
    public class CompanyEditController : ApiController<CompanyEditRequest>
    {
        public CompanyEditController(IApiRequestHandler<CompanyEditRequest> handler, IValidator<CompanyEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
