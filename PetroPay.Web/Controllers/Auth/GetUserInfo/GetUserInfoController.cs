using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    [Authorize(Policy = nameof(Policies.ActiveUser))]
    [Route(Endpoints.ApiUserInfo)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class GetUserInfoController : ApiController<GetUserInfoRequest>
    {
        public GetUserInfoController(IApiRequestHandler<GetUserInfoRequest> handler, IValidator<GetUserInfoRequest> validator) : base(handler, validator)
        {
        }
    }
}
