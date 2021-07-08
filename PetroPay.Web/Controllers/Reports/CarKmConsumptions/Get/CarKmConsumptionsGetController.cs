using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarKmConsumptions.Get
{
    [Route(Endpoints.ApiCarKmConsumptionGet)]
    [ApiExplorerSettings(GroupName = "CarKmConsumption")]
    [Authorize]
    public class CarKmConsumptionGetController : ApiController<CarKmConsumptionGetRequest>
    {
        public CarKmConsumptionGetController(IApiRequestHandler<CarKmConsumptionGetRequest> handler, IValidator<CarKmConsumptionGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
