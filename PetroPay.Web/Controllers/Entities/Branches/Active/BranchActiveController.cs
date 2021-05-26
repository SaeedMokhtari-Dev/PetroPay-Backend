using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Active
{
    [Route(Endpoints.ApiBranchActive)]
    [ApiExplorerSettings(GroupName = "Branch")]
    [Authorize]
    public class BranchActiveController : ApiController<BranchActiveRequest>
    {
        public BranchActiveController(IApiRequestHandler<BranchActiveRequest> handler, IValidator<BranchActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
