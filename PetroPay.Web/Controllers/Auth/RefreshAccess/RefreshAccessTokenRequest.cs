namespace PetroPay.Web.Controllers.Auth.RefreshAccess
{
    public class RefreshAccessTokenRequest
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
