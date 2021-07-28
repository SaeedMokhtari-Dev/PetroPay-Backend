using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.CarBrandMasters.List
{
    [Route(Endpoints.ApiCarBrandMasterList)]
    [ApiExplorerSettings(GroupName = "CarBrandMaster")]
    [Authorize]
    public class CarBrandMasterListController : ApiController<CarBrandMasterListRequest>
    {
        public CarBrandMasterListController(IApiRequestHandler<CarBrandMasterListRequest> handler, IValidator<CarBrandMasterListRequest> validator) : base(handler, validator)
        {
        }
    }
}
