using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Detail
{
    [Route(Endpoints.ApiEmployeeMenuDetail)]
    [ApiExplorerSettings(GroupName = "EmployeeMenu")]
    [Authorize]
    public class EmployeeMenuDetailController : ApiController<EmployeeMenuDetailRequest>
    {
        public EmployeeMenuDetailController(IApiRequestHandler<EmployeeMenuDetailRequest> handler, IValidator<EmployeeMenuDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
