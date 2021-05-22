using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.List
{
    [Route(Endpoints.ApiBranchList)]
    [ApiExplorerSettings(GroupName = "Branch")]
    [Authorize]
    public class BranchListController : ApiController<BranchListRequest>
    {
        public BranchListController(IApiRequestHandler<BranchListRequest> handler, IValidator<BranchListRequest> validator) : base(handler, validator)
        {
        }
    }
}
