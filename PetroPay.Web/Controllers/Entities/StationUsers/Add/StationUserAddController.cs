using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Add
{
    [Route(Endpoints.ApiStationUserAdd)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    [Authorize]
    public class StationUserAddController : ApiController<StationUserAddRequest>
    {
        public StationUserAddController(IApiRequestHandler<StationUserAddRequest> handler, IValidator<StationUserAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
