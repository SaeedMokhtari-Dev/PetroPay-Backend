using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CarBalances.Get
{
    [Route(Endpoints.ApiCarBalanceGet)]
    [ApiExplorerSettings(GroupName = "CarBalance")]
    public class CarBalanceGetController : ApiController<CarBalanceGetRequest>
    {
        public CarBalanceGetController(IApiRequestHandler<CarBalanceGetRequest> handler, IValidator<CarBalanceGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
