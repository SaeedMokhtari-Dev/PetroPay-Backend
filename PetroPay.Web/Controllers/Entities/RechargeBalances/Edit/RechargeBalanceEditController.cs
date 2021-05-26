using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Edit
{
    [Route(Endpoints.ApiRechargeBalanceEdit)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    [Authorize]
    public class RechargeBalanceEditController : ApiController<RechargeBalanceEditRequest>
    {
        public RechargeBalanceEditController(IApiRequestHandler<RechargeBalanceEditRequest> handler, IValidator<RechargeBalanceEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
