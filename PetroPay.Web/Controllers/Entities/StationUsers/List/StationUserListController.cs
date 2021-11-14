using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.List
{
    [Route(Endpoints.ApiStationUserList)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    [Authorize]
    public class StationUserListController : ApiController<StationUserListRequest>
    {
        public StationUserListController(IApiRequestHandler<StationUserListRequest> handler, IValidator<StationUserListRequest> validator) : base(handler, validator)
        {
        }
    }
}
