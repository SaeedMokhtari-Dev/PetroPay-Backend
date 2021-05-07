using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Add
{
    public class CarAddValidator : AbstractValidator<CarAddRequest>
    {
        public CarAddValidator()
        {
            RuleFor(x => x.CompanyBarnchId).NotEmpty().WithMessage(ApiMessages.CarMessage.CompanyBranchIdRequired);
            RuleFor(x => x.CarDriverPassword).MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.MinPasswordLengthError);
            /*RuleFor(x => x.AuditingCarId).NotEmpty().WithMessage(ApiMessages.CarMessage.AuditingCarIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.CarMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.CarMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.CarMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.CarMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.CarMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.CarMessage.FunctionRequired);*/
            
        }
    }
}
