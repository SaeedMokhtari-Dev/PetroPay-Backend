using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Delete
{
    [Route(Endpoints.ApiPetrolCompanyDelete)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyDeleteController : ApiController<PetrolCompanyDeleteRequest>
    {
        public PetrolCompanyDeleteController(IApiRequestHandler<PetrolCompanyDeleteRequest> handler, IValidator<PetrolCompanyDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
