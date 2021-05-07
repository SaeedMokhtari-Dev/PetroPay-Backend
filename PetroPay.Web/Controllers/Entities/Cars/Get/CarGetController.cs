using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Get
{
    [Route(Endpoints.ApiCarGet)]
    [ApiExplorerSettings(GroupName = "Car")]
    public class CarGetController : ApiController<CarGetRequest>
    {
        public CarGetController(IApiRequestHandler<CarGetRequest> handler, IValidator<CarGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
