using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.List
{
    [Route(Endpoints.ApiPetropayAccountList)]
    [ApiExplorerSettings(GroupName = "PetropayAccount")]
    [Authorize]
    public class PetropayAccountListController : ApiController<PetropayAccountListRequest>
    {
        public PetropayAccountListController(IApiRequestHandler<PetropayAccountListRequest> handler, IValidator<PetropayAccountListRequest> validator) : base(handler, validator)
        {
        }
    }
}
