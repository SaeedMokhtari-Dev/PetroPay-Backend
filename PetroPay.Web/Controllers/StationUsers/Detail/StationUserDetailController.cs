using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.StationUsers.Detail
{
    [Route(Endpoints.ApiStationUserDetail)]
    [ApiExplorerSettings(GroupName = "StationUser")]
    public class StationUserDetailController : ApiController<StationUserDetailRequest>
    {
        public StationUserDetailController(IApiRequestHandler<StationUserDetailRequest> handler, IValidator<StationUserDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
