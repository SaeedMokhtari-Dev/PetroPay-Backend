using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Edit
{
    [Route(Endpoints.ApiPetrolCompanyEdit)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyEditController : ApiController<PetrolCompanyEditRequest>
    {
        public PetrolCompanyEditController(IApiRequestHandler<PetrolCompanyEditRequest> handler, IValidator<PetrolCompanyEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
