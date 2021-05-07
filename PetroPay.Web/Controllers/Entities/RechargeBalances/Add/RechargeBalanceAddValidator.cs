using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Add
{
    public class RechargeBalanceAddValidator : AbstractValidator<RechargeBalanceAddRequest>
    {
        public RechargeBalanceAddValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.CompanyIdRequired);
            
            /*RuleFor(x => x.AuditingRechargeBalanceId).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.AuditingRechargeBalanceIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.RechargeBalanceMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.RechargeBalanceMessage.FunctionRequired);*/
            
        }
    }
}
