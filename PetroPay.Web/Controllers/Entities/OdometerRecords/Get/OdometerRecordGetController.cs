using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    [Route(Endpoints.ApiOdometerRecordGet)]
    [ApiExplorerSettings(GroupName = "OdometerRecord")]
    [Authorize]
    public class OdometerRecordGetController : ApiController<OdometerRecordGetRequest>
    {
        public OdometerRecordGetController(IApiRequestHandler<OdometerRecordGetRequest> handler, IValidator<OdometerRecordGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
