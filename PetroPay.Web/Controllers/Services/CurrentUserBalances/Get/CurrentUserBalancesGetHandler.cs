using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Services.CurrentUserBalances.Get
{
    public class CurrentUserBalanceGetHandler : ApiRequestHandler<CurrentUserBalanceGetRequest>
    {
        private readonly UserContext _userContext;

        public CurrentUserBalanceGetHandler(
            UserContext userContext)
        {
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CurrentUserBalanceGetRequest request)
        {
            return ActionResult.Ok(new CurrentUserBalanceGetResponse(_userContext.Balance));
        }
    }
}
