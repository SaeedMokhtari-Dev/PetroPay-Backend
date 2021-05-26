using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Delete
{
    [Route(Endpoints.ApiPetroStationDelete)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    [Authorize]
    public class PetroStationDeleteController : ApiController<PetroStationDeleteRequest>
    {
        public PetroStationDeleteController(IApiRequestHandler<PetroStationDeleteRequest> handler, IValidator<PetroStationDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
