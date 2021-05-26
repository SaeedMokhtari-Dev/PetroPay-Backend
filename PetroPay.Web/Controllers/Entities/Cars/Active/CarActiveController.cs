using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Active
{
    [Route(Endpoints.ApiCarActive)]
    [ApiExplorerSettings(GroupName = "Car")]
    [Authorize]
    public class CarActiveController : ApiController<CarActiveRequest>
    {
        public CarActiveController(IApiRequestHandler<CarActiveRequest> handler, IValidator<CarActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
