using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolPrices.List
{
    [Route(Endpoints.ApiPetrolPriceList)]
    [ApiExplorerSettings(GroupName = "PetrolPrice")]
    [Authorize]
    public class PetrolPriceListController : ApiController<PetrolPriceListRequest>
    {
        public PetrolPriceListController(IApiRequestHandler<PetrolPriceListRequest> handler, IValidator<PetrolPriceListRequest> validator) : base(handler, validator)
        {
        }
    }
}
