namespace PetroPay.Web.Configuration.Constants
{
    public static class Endpoints
    {
        /*Auth APIs*/
        public const string ApiAuthLogin = "/api/auth/login";
        public const string ApiAuthResetPassword = "/api/auth/reset-password";
        public const string ApiAuthValidateResetPasswordToken = "/api/auth/validate-reset-password-token";
        public const string ApiAuthChangePassword = "/api/auth/change-password";
        public const string ApiAuthLogout = "/api/auth/logout";
        public const string ApiAuthCheck = "/api/auth/check";
        public const string ApiAuthRefreshAccessToken = "/api/auth/refresh-access-token";
        public const string ApiUserInfo = "/api/user/info";
        
        /*Company APIs*/
        public const string ApiCompanyAdd = "/api/company/add";
        public const string ApiCompanyEdit = "/api/company/edit";
        public const string ApiCompanyGet = "/api/company/get";
        public const string ApiCompanyDetail = "/api/company/detail";
        public const string ApiCompanyDelete = "/api/company/delete";
        
        /*Bundle APIs*/
        public const string ApiBundleAdd = "/api/bundle/add";
        public const string ApiBundleEdit = "/api/bundle/edit";
        public const string ApiBundleGet = "/api/bundle/get";
        public const string ApiBundleDetail = "/api/bundle/detail";
        public const string ApiBundleDelete = "/api/bundle/delete";
        
        /*admin APIs*/
        public const string ApiUserGet = "/api/user/get";
        public const string ApiUserAdd = "/api/user/add";
        public const string ApiUserEdit = "/api/user/edit";
        public const string ApiUserDetail = "/api/user/detail";
        

        public const string ApiLog = "/api/log";
        public const string Swagger = "/swagger/v1/swagger.json";
    }
}
