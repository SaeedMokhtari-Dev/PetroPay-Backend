using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Delete
{
    [Route(Endpoints.ApiStationUserDelete)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    [Authorize]
    public class StationUserDeleteController : ApiController<StationUserDeleteRequest>
    {
        public StationUserDeleteController(IApiRequestHandler<StationUserDeleteRequest> handler, IValidator<StationUserDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
