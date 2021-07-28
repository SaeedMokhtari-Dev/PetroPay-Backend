using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.CarModelMasters.List
{
    [Route(Endpoints.ApiCarModelMasterList)]
    [ApiExplorerSettings(GroupName = "CarModelMaster")]
    [Authorize]
    public class CarModelMasterListController : ApiController<CarModelMasterListRequest>
    {
        public CarModelMasterListController(IApiRequestHandler<CarModelMasterListRequest> handler, IValidator<CarModelMasterListRequest> validator) : base(handler, validator)
        {
        }
    }
}
