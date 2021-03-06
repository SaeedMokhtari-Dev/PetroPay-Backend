using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Bundles.Get
{
    [Route(Endpoints.ApiBundleGet)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    [Authorize]
    public class BundleGetController : ApiController<BundleGetRequest>
    {
        public BundleGetController(IApiRequestHandler<BundleGetRequest> handler, IValidator<BundleGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
