using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Delete
{
    [Route(Endpoints.ApiAppSettingDelete)]
    [ApiExplorerSettings(GroupName = "AppSetting")]
    [Authorize]
    public class AppSettingDeleteController : ApiController<AppSettingDeleteRequest>
    {
        public AppSettingDeleteController(IApiRequestHandler<AppSettingDeleteRequest> handler, IValidator<AppSettingDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
