using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Delete
{
    public class AppSettingDeleteValidator : AbstractValidator<AppSettingDeleteRequest>
    {
        public AppSettingDeleteValidator()
        {
            RuleFor(x => x.AppSettingsId).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.IdRequired);
        }
    }
}
