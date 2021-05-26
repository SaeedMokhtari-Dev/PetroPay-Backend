using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.PetrolStationLists.Get
{
    [Route(Endpoints.ApiPetrolStationListGet)]
    [ApiExplorerSettings(GroupName = "PetrolStationList")]
    [Authorize]
    public class PetrolStationListGetController : ApiController<PetrolStationListGetRequest>
    {
        public PetrolStationListGetController(IApiRequestHandler<PetrolStationListGetRequest> handler, IValidator<PetrolStationListGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
