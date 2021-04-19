namespace PetroPay.Core.Constants
{
    public static class ApiMessages
    {
        public const string ResourceNotFound = "Api.Resource.Not.Found";
        public const string InvalidRequest = "Api.Invalid.Request";
        public const string GenericError = "Api.Generic.Error";
        public const string Forbidden = "Api.Forbidden";
        public const string PageSize = "Api.PageSize";
        public const string PageIndex = "Api.PageIndex";

        public static class Auth
        {
            public const string UsernameRequired = "Api.Auth.Username.Required";
            public const string PasswordRequired = "Api.Auth.Password.Required";
            public const string RoleTypeRequired = "Api.Auth.RoleType.Required";
            public const string TokenRequired = "Api.Auth.Token.Required";
            public const string InvalidCredentials = "Api.Auth.Invalid.Credentials";
            public const string ResetPasswordResponse = "Api.Auth.ResetPassword.Response";
            
            public const string ValidateResetPasswordTokenInvalidToken = "Api.Auth.ValidateResetPasswordToken.InvalidToken";
            public const string ValidateResetPasswordTokenValidToken = "Api.Auth.ValidateResetPasswordToken.ValidToken";
            
            public const string ChangePasswordNotEqualsPasswords = "Api.Auth.ChangePassword.NotEqualPasswords";
            public const string ChangePasswordSuccessful = "Api.Auth.ChangePassword.Successful";

            public const string MinPasswordLengthError = "Api.Auth.MinPasswordLengthError";
        }
        public static class CompanyMessage
        {
            public const string IdRequired = "Api.Company.Id.Required";
            public const string NameRequired = "Api.Company.Name.Required";
            public const string EmailRequired = "Api.Company.Email.Required";
            public const string LogoRequired = "Api.Company.Logo.Required";
            public const string EmailIsDuplicate = "Api.Company.Email.Duplicate";
            public const string EmailIsWrong = "Api.Company.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.Company.Add.Successful";
            public const string EditedSuccessfully = "Api.Company.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Company.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Company.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Company.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class User
        {
            public const string UserIdRequired = "Api.User.UserId.Required";
            public const string CompanyIdRequired = "Api.User.CompanyId.Required";
            public const string FirstNameRequired = "Api.User.FirstName.Required";    
            public const string LastNameRequired = "Api.User.LastName.Required";    
            public const string EmailRequired = "Api.User.Email.Required";    
            public const string FaxRequired = "Api.User.Fax.Required";    
            public const string PhoneRequired = "Api.User.Phone.Required";    
            public const string FunctionRequired = "Api.User.Function.Required";    
            public const string PasswordRequired = "Api.User.Password.Required";
            public const string EmailIsDuplicate = "Api.User.Email.Duplicate";
            public const string MinPasswordLengthError = "Api.User.Password.MinPasswordLengthError";
        }
    }
}
