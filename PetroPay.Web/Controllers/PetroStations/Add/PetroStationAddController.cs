using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Add
{
    [Route(Endpoints.ApiPetroStationAdd)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    public class PetroStationAddController : ApiController<PetroStationAddRequest>
    {
        public PetroStationAddController(IApiRequestHandler<PetroStationAddRequest> handler, IValidator<PetroStationAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
