using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Edit
{
    [Route(Endpoints.ApiStationUserEdit)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    [Authorize]
    public class StationUserEditController : ApiController<StationUserEditRequest>
    {
        public StationUserEditController(IApiRequestHandler<StationUserEditRequest> handler, IValidator<StationUserEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
