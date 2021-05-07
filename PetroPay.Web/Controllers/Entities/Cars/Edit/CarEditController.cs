using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Edit
{
    [Route(Endpoints.ApiCarEdit)]
    [ApiExplorerSettings(GroupName = "Car")]
    public class CarEditController : ApiController<CarEditRequest>
    {
        public CarEditController(IApiRequestHandler<CarEditRequest> handler, IValidator<CarEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
