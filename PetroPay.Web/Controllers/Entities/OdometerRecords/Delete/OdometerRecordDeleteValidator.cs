using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Delete
{
    public class OdometerRecordDeleteValidator : AbstractValidator<OdometerRecordDeleteRequest>
    {
        public OdometerRecordDeleteValidator()
        {
            RuleFor(x => x.OdometerRecordId).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.IdRequired);
        }
    }
}
