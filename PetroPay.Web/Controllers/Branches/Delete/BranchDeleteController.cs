using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Branches.Delete
{
    [Route(Endpoints.ApiBranchDelete)]
    [ApiExplorerSettings(GroupName = "Branch")]
    public class BranchDeleteController : ApiController<BranchDeleteRequest>
    {
        public BranchDeleteController(IApiRequestHandler<BranchDeleteRequest> handler, IValidator<BranchDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
