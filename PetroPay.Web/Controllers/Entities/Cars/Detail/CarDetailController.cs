using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Detail
{
    [Route(Endpoints.ApiCarDetail)]
    [ApiExplorerSettings(GroupName = "Car")]
    [Authorize]
    public class CarDetailController : ApiController<CarDetailRequest>
    {
        public CarDetailController(IApiRequestHandler<CarDetailRequest> handler, IValidator<CarDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
