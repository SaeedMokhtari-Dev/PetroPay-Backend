using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Get
{
    [Route(Endpoints.ApiStationUserGet)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    [Authorize]
    public class StationUserGetController : ApiController<StationUserGetRequest>
    {
        public StationUserGetController(IApiRequestHandler<StationUserGetRequest> handler, IValidator<StationUserGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
