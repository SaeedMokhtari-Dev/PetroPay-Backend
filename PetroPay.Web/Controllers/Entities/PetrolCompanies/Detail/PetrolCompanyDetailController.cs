using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Detail
{
    [Route(Endpoints.ApiPetrolCompanyDetail)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyDetailController : ApiController<PetrolCompanyDetailRequest>
    {
        public PetrolCompanyDetailController(IApiRequestHandler<PetrolCompanyDetailRequest> handler, IValidator<PetrolCompanyDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
