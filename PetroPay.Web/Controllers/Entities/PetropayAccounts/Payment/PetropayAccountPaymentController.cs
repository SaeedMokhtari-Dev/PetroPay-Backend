using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Payment
{
    [Route(Endpoints.ApiPetropayAccountPayment)]
    [ApiExplorerSettings(GroupName = "PetropayAccount")]
    [Authorize]
    public class PetropayAccountPaymentController : ApiController<PetropayAccountPaymentRequest>
    {
        public PetropayAccountPaymentController(IApiRequestHandler<PetropayAccountPaymentRequest> handler, IValidator<PetropayAccountPaymentRequest> validator) : base(handler, validator)
        {
        }
    }
}
