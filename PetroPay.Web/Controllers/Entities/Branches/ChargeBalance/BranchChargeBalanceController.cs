using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Branches.ChargeBalance
{
    [Route(Endpoints.ApiBranchChargeBalance)]
    [ApiExplorerSettings(GroupName = "Branch")]
    public class BranchChargeBalanceController : ApiController<BranchChargeBalanceRequest>
    {
        public BranchChargeBalanceController(IApiRequestHandler<BranchChargeBalanceRequest> handler, IValidator<BranchChargeBalanceRequest> validator) : base(handler, validator)
        {
        }
    }
}
