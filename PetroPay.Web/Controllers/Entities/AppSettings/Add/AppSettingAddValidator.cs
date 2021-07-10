using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Add
{
    public class AppSettingAddValidator : AbstractValidator<AppSettingAddRequest>
    {
        public AppSettingAddValidator()
        {
            /*RuleFor(x => x.AuditingAppSettingId).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.AuditingAppSettingIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.AppSettingMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.AppSettingMessage.FunctionRequired);*/
            
        }
    }
}
