using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Add
{
    [Route(Endpoints.ApiEmployeeMenuAdd)]
    [ApiExplorerSettings(GroupName = "EmployeeMenu")]
    [Authorize]
    public class EmployeeMenuAddController : ApiController<EmployeeMenuAddRequest>
    {
        public EmployeeMenuAddController(IApiRequestHandler<EmployeeMenuAddRequest> handler, IValidator<EmployeeMenuAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
