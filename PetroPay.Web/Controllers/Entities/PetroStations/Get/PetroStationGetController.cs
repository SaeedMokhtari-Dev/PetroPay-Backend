using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Get
{
    [Route(Endpoints.ApiPetroStationGet)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    [Authorize]
    public class PetroStationGetController : ApiController<PetroStationGetRequest>
    {
        public PetroStationGetController(IApiRequestHandler<PetroStationGetRequest> handler, IValidator<PetroStationGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
