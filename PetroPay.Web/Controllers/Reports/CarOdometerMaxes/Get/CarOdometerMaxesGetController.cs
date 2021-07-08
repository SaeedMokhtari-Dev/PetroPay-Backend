using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMaxes.Get
{
    [Route(Endpoints.ApiCarOdometerMaxGet)]
    [ApiExplorerSettings(GroupName = "CarOdometerMax")]
    [Authorize]
    public class CarOdometerMaxGetController : ApiController<CarOdometerMaxGetRequest>
    {
        public CarOdometerMaxGetController(IApiRequestHandler<CarOdometerMaxGetRequest> handler, IValidator<CarOdometerMaxGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
