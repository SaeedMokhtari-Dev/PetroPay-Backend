using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.StationReports.Get
{
    [Route(Endpoints.ApiStationReportGet)]
    [ApiExplorerSettings(GroupName = "StationReport")]
    public class StationReportGetController : ApiController<StationReportGetRequest>
    {
        public StationReportGetController(IApiRequestHandler<StationReportGetRequest> handler, IValidator<StationReportGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
