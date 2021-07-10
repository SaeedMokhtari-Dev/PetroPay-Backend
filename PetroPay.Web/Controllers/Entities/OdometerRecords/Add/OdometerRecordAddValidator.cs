using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Add
{
    public class OdometerRecordAddValidator : AbstractValidator<OdometerRecordAddRequest>
    {
        public OdometerRecordAddValidator()
        {
            /*RuleFor(x => x.AuditingOdometerRecordId).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.AuditingOdometerRecordIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.OdometerRecordMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.FunctionRequired);*/
            
        }
    }
}
