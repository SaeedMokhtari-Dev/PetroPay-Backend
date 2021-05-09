using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.StationSales.Get
{
    [Route(Endpoints.ApiStationSaleGet)]
    [ApiExplorerSettings(GroupName = "StationSale")]
    public class StationSaleGetController : ApiController<StationSaleGetRequest>
    {
        public StationSaleGetController(IApiRequestHandler<StationSaleGetRequest> handler, IValidator<StationSaleGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
