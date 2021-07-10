using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Edit
{
    [Route(Endpoints.ApiOdometerRecordEdit)]
    [ApiExplorerSettings(GroupName = "OdometerRecord")]
    [Authorize]
    public class OdometerRecordEditController : ApiController<OdometerRecordEditRequest>
    {
        public OdometerRecordEditController(IApiRequestHandler<OdometerRecordEditRequest> handler, IValidator<OdometerRecordEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
