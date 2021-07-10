using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Edit
{
    public class OdometerRecordEditValidator : AbstractValidator<OdometerRecordEditRequest>
    {
        public OdometerRecordEditValidator()
        {
            RuleFor(x => x.OdometerRecordId).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.IdRequired);
        }
    }
}
