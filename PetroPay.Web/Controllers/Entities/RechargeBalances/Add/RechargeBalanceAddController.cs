using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Add
{
    [Route(Endpoints.ApiRechargeBalanceAdd)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceAddController : ApiController<RechargeBalanceAddRequest>
    {
        public RechargeBalanceAddController(IApiRequestHandler<RechargeBalanceAddRequest> handler, IValidator<RechargeBalanceAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
