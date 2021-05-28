using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Dashboards.Admin.Get
{
    [Route(Endpoints.ApiDashboardAdminGet)]
    [ApiExplorerSettings(GroupName = "Admin")]
    [Authorize]
    public class AdminGetController : ApiController<AdminGetRequest>
    {
        public AdminGetController(IApiRequestHandler<AdminGetRequest> handler, IValidator<AdminGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
