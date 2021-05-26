using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Add
{
    [Route(Endpoints.ApiBranchAdd)]
    [ApiExplorerSettings(GroupName = "Branch")]
    [Authorize]
    public class BranchAddController : ApiController<BranchAddRequest>
    {
        public BranchAddController(IApiRequestHandler<BranchAddRequest> handler, IValidator<BranchAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
