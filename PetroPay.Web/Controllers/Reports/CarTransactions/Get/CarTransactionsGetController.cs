using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarTransactions.Get
{
    [Route(Endpoints.ApiCarTransactionGet)]
    [ApiExplorerSettings(GroupName = "CarTransaction")]
    [Authorize]
    public class CarTransactionGetController : ApiController<CarTransactionGetRequest>
    {
        public CarTransactionGetController(IApiRequestHandler<CarTransactionGetRequest> handler, IValidator<CarTransactionGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
