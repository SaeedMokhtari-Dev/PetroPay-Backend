using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Get
{
    [Route(Endpoints.ApiPetropayAccountGet)]
    [ApiExplorerSettings(GroupName = "PetropayAccount")]
    [Authorize]
    public class PetropayAccountGetController : ApiController<PetropayAccountGetRequest>
    {
        public PetropayAccountGetController(IApiRequestHandler<PetropayAccountGetRequest> handler, IValidator<PetropayAccountGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
