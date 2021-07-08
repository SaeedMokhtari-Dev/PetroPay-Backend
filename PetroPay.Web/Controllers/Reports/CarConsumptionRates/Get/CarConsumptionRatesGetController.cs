using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarConsumptionRates.Get
{
    [Route(Endpoints.ApiCarConsumptionRateGet)]
    [ApiExplorerSettings(GroupName = "CarConsumptionRate")]
    [Authorize]
    public class CarConsumptionRateGetController : ApiController<CarConsumptionRateGetRequest>
    {
        public CarConsumptionRateGetController(IApiRequestHandler<CarConsumptionRateGetRequest> handler, IValidator<CarConsumptionRateGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
