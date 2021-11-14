using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Add
{
    [Route(Endpoints.ApiPetrolCompanyAdd)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyAddController : ApiController<PetrolCompanyAddRequest>
    {
        public PetrolCompanyAddController(IApiRequestHandler<PetrolCompanyAddRequest> handler, IValidator<PetrolCompanyAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
