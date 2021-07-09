using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.OdometerBetweenDates.Get
{
    [Route(Endpoints.ApiOdometerBetweenDateGet)]
    [ApiExplorerSettings(GroupName = "OdometerBetweenDate")]
    [Authorize]
    public class OdometerBetweenDateGetController : ApiController<OdometerBetweenDateGetRequest>
    {
        public OdometerBetweenDateGetController(IApiRequestHandler<OdometerBetweenDateGetRequest> handler, IValidator<OdometerBetweenDateGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
