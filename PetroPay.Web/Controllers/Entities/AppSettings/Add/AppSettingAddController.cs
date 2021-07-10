using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Add
{
    [Route(Endpoints.ApiAppSettingAdd)]
    [ApiExplorerSettings(GroupName = "AppSetting")]
    [Authorize]
    public class AppSettingAddController : ApiController<AppSettingAddRequest>
    {
        public AppSettingAddController(IApiRequestHandler<AppSettingAddRequest> handler, IValidator<AppSettingAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
