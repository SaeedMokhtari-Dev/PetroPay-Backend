using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Bundles.Delete
{
    [Route(Endpoints.ApiBundleDelete)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    [Authorize]
    public class BundleDeleteController : ApiController<BundleDeleteRequest>
    {
        public BundleDeleteController(IApiRequestHandler<BundleDeleteRequest> handler, IValidator<BundleDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
