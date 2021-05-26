using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Delete
{
    [Route(Endpoints.ApiRechargeBalanceDelete)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceDeleteController : ApiController<RechargeBalanceDeleteRequest>
    {
        public RechargeBalanceDeleteController(IApiRequestHandler<RechargeBalanceDeleteRequest> handler, IValidator<RechargeBalanceDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
