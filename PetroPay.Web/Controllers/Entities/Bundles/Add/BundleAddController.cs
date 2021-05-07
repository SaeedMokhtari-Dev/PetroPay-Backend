using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Bundles.Add
{
    [Route(Endpoints.ApiBundleAdd)]
    [ApiExplorerSettings(GroupName = "Bundle")]
    public class BundleAddController : ApiController<BundleAddRequest>
    {
        public BundleAddController(IApiRequestHandler<BundleAddRequest> handler, IValidator<BundleAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
