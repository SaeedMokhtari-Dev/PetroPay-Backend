using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Get
{
    [Route(Endpoints.ApiPetrolCompanyGet)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyGetController : ApiController<PetrolCompanyGetRequest>
    {
        public PetrolCompanyGetController(IApiRequestHandler<PetrolCompanyGetRequest> handler, IValidator<PetrolCompanyGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
