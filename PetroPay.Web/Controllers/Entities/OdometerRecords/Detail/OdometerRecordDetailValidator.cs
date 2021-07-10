using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Detail
{
    public class OdometerRecordDetailValidator : AbstractValidator<OdometerRecordDetailRequest>
    {
        public OdometerRecordDetailValidator()
        {
            RuleFor(x => x.OdometerRecordId).NotEmpty().WithMessage(ApiMessages.OdometerRecordMessage.IdRequired);
        }
    }
}
