using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Get
{
    [Route(Endpoints.ApiAccountBalanceGet)]
    [ApiExplorerSettings(GroupName = "AccountBalance")]
    [Authorize]
    public class AccountBalanceGetController : ApiController<AccountBalanceGetRequest>
    {
        public AccountBalanceGetController(IApiRequestHandler<AccountBalanceGetRequest> handler, IValidator<AccountBalanceGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
