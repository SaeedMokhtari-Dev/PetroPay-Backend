using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Edit
{
    [Route(Endpoints.ApiPetroStationEdit)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    public class PetroStationEditController : ApiController<PetroStationEditRequest>
    {
        public PetroStationEditController(IApiRequestHandler<PetroStationEditRequest> handler, IValidator<PetroStationEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
