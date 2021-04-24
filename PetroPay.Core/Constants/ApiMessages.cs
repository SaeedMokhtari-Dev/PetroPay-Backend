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
        public static class BranchMessage
        {
            public const string CompanyIdRequired = "Api.Branch.CompanyId.Required";
            public const string IdRequired = "Api.Branch.Id.Required";
            public const string NameRequired = "Api.Branch.Name.Required";
            public const string EmailRequired = "Api.Branch.Email.Required";
            public const string LogoRequired = "Api.Branch.Logo.Required";
            public const string EmailIsDuplicate = "Api.Branch.Email.Duplicate";
            public const string EmailIsWrong = "Api.Branch.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.Branch.Add.Successful";
            public const string EditedSuccessfully = "Api.Branch.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Branch.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Branch.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Branch.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class PetroStationMessage
        {
            public const string CompanyIdRequired = "Api.PetroStation.CompanyId.Required";
            public const string IdRequired = "Api.PetroStation.Id.Required";
            public const string NameRequired = "Api.PetroStation.Name.Required";
            public const string EmailRequired = "Api.PetroStation.Email.Required";
            public const string LogoRequired = "Api.PetroStation.Logo.Required";
            public const string EmailIsDuplicate = "Api.PetroStation.Email.Duplicate";
            public const string EmailIsWrong = "Api.PetroStation.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.PetroStation.Add.Successful";
            public const string EditedSuccessfully = "Api.PetroStation.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.PetroStation.Archived.Successful";
            public const string DeletedSuccessfully = "Api.PetroStation.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.PetroStation.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class StationUserMessage
        {
            public const string StationIdRequired = "Api.StationUser.StationId.Required";
            public const string IdRequired = "Api.StationUser.Id.Required";
            public const string NameRequired = "Api.StationUser.Name.Required";
            public const string EmailRequired = "Api.StationUser.Email.Required";
            public const string LogoRequired = "Api.StationUser.Logo.Required";
            public const string EmailIsDuplicate = "Api.StationUser.Email.Duplicate";
            public const string EmailIsWrong = "Api.StationUser.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.StationUser.Add.Successful";
            public const string EditedSuccessfully = "Api.StationUser.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.StationUser.Archived.Successful";
            public const string DeletedSuccessfully = "Api.StationUser.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.StationUser.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class BundleMessage
        {
            public const string IdRequired = "Api.Bundle.Id.Required";
            public const string NameRequired = "Api.Bundle.Name.Required";
            public const string EmailRequired = "Api.Bundle.Email.Required";
            public const string LogoRequired = "Api.Bundle.Logo.Required";
            public const string EmailIsDuplicate = "Api.Bundle.Email.Duplicate";
            public const string EmailIsWrong = "Api.Bundle.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.Bundle.Add.Successful";
            public const string EditedSuccessfully = "Api.Bundle.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Bundle.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Bundle.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Bundle.ArchivedEntityEdit.NotAllowed";
            
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
