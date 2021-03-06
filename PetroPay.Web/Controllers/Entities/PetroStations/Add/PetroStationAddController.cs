using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Add
{
    [Route(Endpoints.ApiPetroStationAdd)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    [Authorize]
    public class PetroStationAddController : ApiController<PetroStationAddRequest>
    {
        public PetroStationAddController(IApiRequestHandler<PetroStationAddRequest> handler, IValidator<PetroStationAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
