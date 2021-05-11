using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.ChangeUserPassword
{
    public class ChangeUserPasswordRequest
    {
        public string CurrentPassword { get; set; }
        
        public string NewPassword { get; set; }
        
        public string ConfirmPassword { get; set; }
    }
}
