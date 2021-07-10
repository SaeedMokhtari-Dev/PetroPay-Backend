using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoHandler : ApiRequestHandler<GetUserInfoRequest>
    {
        private readonly UserService _userService;

        public GetUserInfoHandler(UserService userService)
        {
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(GetUserInfoRequest request)
        {
            var user = await _userService.GetCurrentUserInfo();
            if (user.Item1)
                return ActionResult.Ok(user.Item2);
            return ActionResult.Error(user.Item3);
        }
    }
}
