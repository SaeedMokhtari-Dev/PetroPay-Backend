using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.Delete
{
    [Route(Endpoints.ApiCompanyDelete)]
    [ApiExplorerSettings(GroupName = "Company")]
    public class CompanyDeleteController : ApiController<CompanyDeleteRequest>
    {
        public CompanyDeleteController(IApiRequestHandler<CompanyDeleteRequest> handler, IValidator<CompanyDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
