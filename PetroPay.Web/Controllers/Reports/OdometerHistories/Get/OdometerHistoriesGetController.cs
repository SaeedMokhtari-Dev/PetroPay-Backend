using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.OdometerHistories.Get
{
    [Route(Endpoints.ApiOdometerHistoryGet)]
    [ApiExplorerSettings(GroupName = "OdometerHistory")]
    [Authorize]
    public class OdometerHistoryGetController : ApiController<OdometerHistoryGetRequest>
    {
        public OdometerHistoryGetController(IApiRequestHandler<OdometerHistoryGetRequest> handler, IValidator<OdometerHistoryGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
