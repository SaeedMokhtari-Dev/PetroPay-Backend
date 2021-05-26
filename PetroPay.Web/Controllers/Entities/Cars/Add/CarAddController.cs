using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Add
{
    [Route(Endpoints.ApiCarAdd)]
    [ApiExplorerSettings(GroupName = "Car")]
    [Authorize]
    public class CarAddController : ApiController<CarAddRequest>
    {
        public CarAddController(IApiRequestHandler<CarAddRequest> handler, IValidator<CarAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
