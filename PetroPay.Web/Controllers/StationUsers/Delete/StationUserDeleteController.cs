using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.StationUsers.Delete
{
    [Route(Endpoints.ApiStationUserDelete)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    public class StationUserDeleteController : ApiController<StationUserDeleteRequest>
    {
        public StationUserDeleteController(IApiRequestHandler<StationUserDeleteRequest> handler, IValidator<StationUserDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
