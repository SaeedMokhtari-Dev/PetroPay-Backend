using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;
using PetroPay.Web.Identity.Handlers.Authorization;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    [Route(Endpoints.ApiRechargeBalanceGet)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceGetController : ApiController<RechargeBalanceGetRequest>
    {
        public RechargeBalanceGetController(IApiRequestHandler<RechargeBalanceGetRequest> handler, IValidator<RechargeBalanceGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
