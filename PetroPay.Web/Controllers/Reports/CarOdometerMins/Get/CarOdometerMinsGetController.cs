using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMins.Get
{
    [Route(Endpoints.ApiCarOdometerMinGet)]
    [ApiExplorerSettings(GroupName = "CarOdometerMin")]
    [Authorize]
    public class CarOdometerMinGetController : ApiController<CarOdometerMinGetRequest>
    {
        public CarOdometerMinGetController(IApiRequestHandler<CarOdometerMinGetRequest> handler, IValidator<CarOdometerMinGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
