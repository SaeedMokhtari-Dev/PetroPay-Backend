using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Branches.Get
{
    [Route(Endpoints.ApiBranchGet)]
    [ApiExplorerSettings(GroupName = "Branch")]
    public class BranchGetController : ApiController<BranchGetRequest>
    {
        public BranchGetController(IApiRequestHandler<BranchGetRequest> handler, IValidator<BranchGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
