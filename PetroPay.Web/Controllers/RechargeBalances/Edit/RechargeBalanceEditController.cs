using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.RechargeBalances.Edit
{
    [Route(Endpoints.ApiRechargeBalanceEdit)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    public class RechargeBalanceEditController : ApiController<RechargeBalanceEditRequest>
    {
        public RechargeBalanceEditController(IApiRequestHandler<RechargeBalanceEditRequest> handler, IValidator<RechargeBalanceEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
