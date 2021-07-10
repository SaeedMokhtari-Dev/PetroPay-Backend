using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Detail
{
    [Route(Endpoints.ApiAppSettingDetail)]
    [ApiExplorerSettings(GroupName = "AppSetting")]
    [Authorize]
    public class AppSettingDetailController : ApiController<AppSettingDetailRequest>
    {
        public AppSettingDetailController(IApiRequestHandler<AppSettingDetailRequest> handler, IValidator<AppSettingDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
