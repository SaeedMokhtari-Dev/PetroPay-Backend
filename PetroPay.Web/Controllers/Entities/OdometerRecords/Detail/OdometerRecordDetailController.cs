using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Detail
{
    [Route(Endpoints.ApiOdometerRecordDetail)]
    [ApiExplorerSettings(GroupName = "OdometerRecord")]
    [Authorize]
    public class OdometerRecordDetailController : ApiController<OdometerRecordDetailRequest>
    {
        public OdometerRecordDetailController(IApiRequestHandler<OdometerRecordDetailRequest> handler, IValidator<OdometerRecordDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
