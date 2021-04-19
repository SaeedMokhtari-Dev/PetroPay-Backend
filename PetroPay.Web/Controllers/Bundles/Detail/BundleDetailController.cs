using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Bundles.Detail
{
    [Route(Endpoints.ApiBundleDetail)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    public class BundleDetailController : ApiController<BundleDetailRequest>
    {
        public BundleDetailController(IApiRequestHandler<BundleDetailRequest> handler, IValidator<BundleDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
