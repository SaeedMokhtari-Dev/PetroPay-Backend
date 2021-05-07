using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.Detail
{
    [Route(Endpoints.ApiCompanyDetail)]
    [ApiExplorerSettings(GroupName = "Company")]
    public class CompanyDetailController : ApiController<CompanyDetailRequest>
    {
        public CompanyDetailController(IApiRequestHandler<CompanyDetailRequest> handler, IValidator<CompanyDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
