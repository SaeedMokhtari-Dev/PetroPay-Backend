using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Cars.Add
{
    [Route(Endpoints.ApiCarAdd)]
    [ApiExplorerSettings(GroupName = "Car")]
    public class CarAddController : ApiController<CarAddRequest>
    {
        public CarAddController(IApiRequestHandler<CarAddRequest> handler, IValidator<CarAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
