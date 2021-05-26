using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Detail
{
    [Route(Endpoints.ApiBranchDetail)]
    [ApiExplorerSettings(GroupName = "Branch")]
    [Authorize]
    public class BranchDetailController : ApiController<BranchDetailRequest>
    {
        public BranchDetailController(IApiRequestHandler<BranchDetailRequest> handler, IValidator<BranchDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
