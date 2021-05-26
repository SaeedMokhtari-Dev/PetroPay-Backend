using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Confirm
{
    [Route(Endpoints.ApiRechargeBalanceConfirm)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceConfirmController : ApiController<RechargeBalanceConfirmRequest>
    {
        public RechargeBalanceConfirmController(IApiRequestHandler<RechargeBalanceConfirmRequest> handler, IValidator<RechargeBalanceConfirmRequest> validator) : base(handler, validator)
        {
        }
    }
}
