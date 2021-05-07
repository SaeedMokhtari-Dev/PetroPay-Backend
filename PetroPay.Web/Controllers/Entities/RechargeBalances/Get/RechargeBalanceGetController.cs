using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    [Route(Endpoints.ApiRechargeBalanceGet)]
    [ApiExplorerSettings(GroupName = "RechargeBalance")]
    public class RechargeBalanceGetController : ApiController<RechargeBalanceGetRequest>
    {
        public RechargeBalanceGetController(IApiRequestHandler<RechargeBalanceGetRequest> handler, IValidator<RechargeBalanceGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
