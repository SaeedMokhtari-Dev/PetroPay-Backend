using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Services.CurrentUserBalances.Get
{
    [Route(Endpoints.ApiCurrentUserBalanceGet)]
    [ApiExplorerSettings(GroupName = "CurrentUserBalance")]
    [Authorize]
    public class CurrentUserBalanceGetController : ApiController<CurrentUserBalanceGetRequest>
    {
        public CurrentUserBalanceGetController(IApiRequestHandler<CurrentUserBalanceGetRequest> handler, IValidator<CurrentUserBalanceGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
