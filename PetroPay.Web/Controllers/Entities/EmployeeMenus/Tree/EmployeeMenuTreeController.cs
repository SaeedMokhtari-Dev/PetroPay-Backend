using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Tree
{
    [Route(Endpoints.ApiEmployeeMenuTree)]
    [ApiExplorerSettings(GroupName = "EmployeeMenu")]
    [Authorize(Policies.AdminUser)]
    public class EmployeeMenuTreeController : ApiController<EmployeeMenuTreeRequest>
    {
        public EmployeeMenuTreeController(IApiRequestHandler<EmployeeMenuTreeRequest> handler, IValidator<EmployeeMenuTreeRequest> validator) : base(handler, validator)
        {
        }
    }
}
