using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Bundles.Get
{
    [Route(Endpoints.ApiBundleGet)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    public class BundleGetController : ApiController<BundleGetRequest>
    {
        public BundleGetController(IApiRequestHandler<BundleGetRequest> handler, IValidator<BundleGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
