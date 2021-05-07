using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Detail
{
    [Route(Endpoints.ApiAccountBalanceDetail)]
    [ApiExplorerSettings(GroupName = "AccountBalance")]
    public class AccountBalanceDetailController : ApiController<AccountBalanceDetailRequest>
    {
        public AccountBalanceDetailController(IApiRequestHandler<AccountBalanceDetailRequest> handler, IValidator<AccountBalanceDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
