using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.Edit
{
    [Route(Endpoints.ApiBranchEdit)]
    [ApiExplorerSettings(GroupName = "Branch")]
    [Authorize]
    public class BranchEditController : ApiController<BranchEditRequest>
    {
        public BranchEditController(IApiRequestHandler<BranchEditRequest> handler, IValidator<BranchEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
