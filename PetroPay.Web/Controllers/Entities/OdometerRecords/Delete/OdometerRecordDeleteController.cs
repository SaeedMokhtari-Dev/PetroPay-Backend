using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Delete
{
    [Route(Endpoints.ApiOdometerRecordDelete)]
    [ApiExplorerSettings(GroupName = "OdometerRecord")]
    [Authorize]
    public class OdometerRecordDeleteController : ApiController<OdometerRecordDeleteRequest>
    {
        public OdometerRecordDeleteController(IApiRequestHandler<OdometerRecordDeleteRequest> handler, IValidator<OdometerRecordDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
