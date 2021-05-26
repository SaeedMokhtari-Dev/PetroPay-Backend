using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Detail
{
    [Route(Endpoints.ApiRechargeBalanceDetail)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceDetailController : ApiController<RechargeBalanceDetailRequest>
    {
        public RechargeBalanceDetailController(IApiRequestHandler<RechargeBalanceDetailRequest> handler, IValidator<RechargeBalanceDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
