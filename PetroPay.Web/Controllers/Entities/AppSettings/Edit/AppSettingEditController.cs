using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Edit
{
    [Route(Endpoints.ApiAppSettingEdit)]
    [ApiExplorerSettings(GroupName = "AppSetting")]
    [Authorize]
    public class AppSettingEditController : ApiController<AppSettingEditRequest>
    {
        public AppSettingEditController(IApiRequestHandler<AppSettingEditRequest> handler, IValidator<AppSettingEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
