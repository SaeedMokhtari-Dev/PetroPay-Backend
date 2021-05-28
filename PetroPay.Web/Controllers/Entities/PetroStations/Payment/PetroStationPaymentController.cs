using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Payment
{
    [Route(Endpoints.ApiPetroStationPayment)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    [Authorize]
    public class PetroStationPaymentController : ApiController<PetroStationPaymentRequest>
    {
        public PetroStationPaymentController(IApiRequestHandler<PetroStationPaymentRequest> handler, IValidator<PetroStationPaymentRequest> validator) : base(handler, validator)
        {
        }
    }
}
