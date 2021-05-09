using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.StationStatements.Get
{
    [Route(Endpoints.ApiStationStatementGet)]
    [ApiExplorerSettings(GroupName = "StationStatement")]
    public class StationStatementGetController : ApiController<StationStatementGetRequest>
    {
        public StationStatementGetController(IApiRequestHandler<StationStatementGetRequest> handler, IValidator<StationStatementGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
