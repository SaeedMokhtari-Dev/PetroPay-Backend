using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Bundles.Edit
{
    [Route(Endpoints.ApiBundleEdit)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    [Authorize]
    public class BundleEditController : ApiController<BundleEditRequest>
    {
        public BundleEditController(IApiRequestHandler<BundleEditRequest> handler, IValidator<BundleEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
