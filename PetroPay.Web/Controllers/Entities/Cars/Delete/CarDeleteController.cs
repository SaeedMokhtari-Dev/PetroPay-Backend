using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Delete
{
    [Route(Endpoints.ApiCarDelete)]
    [ApiExplorerSettings(GroupName = "Car")]
    public class CarDeleteController : ApiController<CarDeleteRequest>
    {
        public CarDeleteController(IApiRequestHandler<CarDeleteRequest> handler, IValidator<CarDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
