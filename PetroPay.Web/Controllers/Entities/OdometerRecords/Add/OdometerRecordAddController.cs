using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Add
{
    [Route(Endpoints.ApiOdometerRecordAdd)]
    [ApiExplorerSettings(GroupName = "OdometerRecord")]
    [Authorize]
    public class OdometerRecordAddController : ApiController<OdometerRecordAddRequest>
    {
        public OdometerRecordAddController(IApiRequestHandler<OdometerRecordAddRequest> handler, IValidator<OdometerRecordAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
