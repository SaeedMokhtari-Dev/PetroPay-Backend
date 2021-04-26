using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.ResetPassword
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public RoleType RoleType { get; set; }
    }
}
