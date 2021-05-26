using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.List
{
    [Route(Endpoints.ApiCarList)]
    [ApiExplorerSettings(GroupName = "Car")]
    [Authorize]
    public class CarListController : ApiController<CarListRequest>
    {
        public CarListController(IApiRequestHandler<CarListRequest> handler, IValidator<CarListRequest> validator) : base(handler, validator)
        {
        }
    }
}
