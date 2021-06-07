using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.List
{
    [Route(Endpoints.ApiPetroStationList)]
    [ApiExplorerSettings(GroupName = "PetroStation")]
    [Authorize]
    public class PetroStationListController : ApiController<PetroStationListRequest>
    {
        public PetroStationListController(IApiRequestHandler<PetroStationListRequest> handler, IValidator<PetroStationListRequest> validator) : base(handler, validator)
        {
        }
    }
}
