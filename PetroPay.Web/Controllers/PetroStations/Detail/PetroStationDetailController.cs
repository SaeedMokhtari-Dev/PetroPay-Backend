using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Detail
{
    [Route(Endpoints.ApiPetroStationDetail)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    public class PetroStationDetailController : ApiController<PetroStationDetailRequest>
    {
        public PetroStationDetailController(IApiRequestHandler<PetroStationDetailRequest> handler, IValidator<PetroStationDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
