using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.List
{
    [Route(Endpoints.ApiPetrolCompanyList)]
    [ApiExplorerSettings(GroupName = "PetrolCompany")]
    [Authorize]
    public class PetrolCompanyListController : ApiController<PetrolCompanyListRequest>
    {
        public PetrolCompanyListController(IApiRequestHandler<PetrolCompanyListRequest> handler, IValidator<PetrolCompanyListRequest> validator) : base(handler, validator)
        {
        }
    }
}
