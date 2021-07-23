using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.CarTypeMasters.List
{
    [Route(Endpoints.ApiCarTypeMasterList)]
    [ApiExplorerSettings(GroupName = "CarTypeMaster")]
    [Authorize]
    public class CarTypeMasterListController : ApiController<CarTypeMasterListRequest>
    {
        public CarTypeMasterListController(IApiRequestHandler<CarTypeMasterListRequest> handler, IValidator<CarTypeMasterListRequest> validator) : base(handler, validator)
        {
        }
    }
}
