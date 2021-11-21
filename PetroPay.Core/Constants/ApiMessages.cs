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
        public const string DuplicateUserName = "Api.Username.Duplicate";
        public const string DuplicateEmail = "Api.Email.Duplicate";
        public const string NotEnoughBalance = "Api.NotEnoughBalance";
        public const string MinPasswordLengthError = "Api.MinPasswordLengthError";
        public const string IdRequired = "Api.Validate.IdRequired";

        public static class Auth
        {
            public const string EmailRequired = "Api.Auth.Email.Required";
            public const string UsernameRequired = "Api.Auth.Username.Required";
            public const string PasswordRequired = "Api.Auth.Password.Required";
            public const string RoleTypeRequired = "Api.Auth.RoleType.Required";
            public const string TokenRequired = "Api.Auth.Token.Required";
            public const string CurrentPasswordRequired = "Api.Auth.CurrentPassword.Required";
            public const string InvalidCredentials = "Api.Auth.Invalid.Credentials";
            public const string ResetPasswordResponse = "Api.Auth.ResetPassword.Response";
            
            public const string ValidateResetPasswordTokenInvalidToken = "Api.Auth.ValidateResetPasswordToken.InvalidToken";
            public const string ValidateResetPasswordTokenValidToken = "Api.Auth.ValidateResetPasswordToken.ValidToken";
            
            public const string ChangePasswordNotEqualsPasswords = "Api.Auth.ChangePassword.NotEqualPasswords";
            public const string ChangePasswordCurrentPasswordIsNotCorrect = "Api.Auth.ChangePassword.CurrentIsNotCorrect";
            public const string ChangePasswordSuccessful = "Api.Auth.ChangePassword.Successful";

            public const string MinPasswordLengthError = "Api.Auth.MinPasswordLengthError";
        }
        public static class CompanyMessage
        {
            public const string IdRequired = "Api.Company.Id.Required";
            public const string NameRequired = "Api.Company.Name.Required";
            public const string EmailRequired = "Api.Company.Email.Required";
            public const string LogoRequired = "Api.Company.Logo.Required";
            public const string EmailIsWrong = "Api.Company.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.Company.Add.Successful";
            public const string EditedSuccessfully = "Api.Company.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Company.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Company.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Company.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class PetrolCompanyMessage
        {
            public const string IdRequired = "Api.PetrolCompany.Id.Required";
            public const string NameRequired = "Api.PetrolCompany.Name.Required";
            public const string EmailRequired = "Api.PetrolCompany.Email.Required";
            public const string LogoRequired = "Api.PetrolCompany.Logo.Required";
            public const string EmailIsWrong = "Api.PetrolCompany.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.PetrolCompany.Add.Successful";
            public const string EditedSuccessfully = "Api.PetrolCompany.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.PetrolCompany.Archived.Successful";
            public const string DeletedSuccessfully = "Api.PetrolCompany.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.PetrolCompany.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class BranchMessage
        {
            public const string CompanyIdRequired = "Api.Branch.CompanyId.Required";
            public const string CompanyBranchIdRequired = "Api.Branch.CompanyBranchId.Required";
            public const string IdRequired = "Api.Branch.IdRequired.Required";
            public const string IncreaseAmountRequired = "Api.Branch.IncreaseAmount.Required";
            public const string NameRequired = "Api.Branch.Name.Required";
            public const string EmailRequired = "Api.Branch.Email.Required";
            public const string LogoRequired = "Api.Branch.Logo.Required";
            public const string EmailIsDuplicate = "Api.Branch.Email.Duplicate";
            public const string EmailIsWrong = "Api.Branch.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.Branch.Add.Successful";
            public const string EditedSuccessfully = "Api.Branch.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Branch.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Branch.Deleted.Successful";
            public const string ActivatedSuccessfully = "Api.Branch.Activated.Successful";
            public const string BalanceIncreasedSuccessfully = "Api.Branch.BalanceIncreased.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Branch.ArchivedEntityEdit.NotAllowed";
            public const string IncreaseAmountCannotBeMoreThanBalance = "Api.Branch.IncreaseAmountCannotBeMoreThanBalance";
            
        }
        public static class CarMessage
        {
            public const string CompanyBranchIdRequired = "Api.Car.CompanyBranchId.Required";
            public const string IdRequired = "Api.Car.Id.Required";
            public const string CarNfcCodeRequired = "Api.Car.CarNfcCode.Required";
            
            public const string AddedSuccessfully = "Api.Car.Add.Successful";
            public const string EditedSuccessfully = "Api.Car.Edit.Successful";
            public const string DeletedSuccessfully = "Api.Car.Deleted.Successful";
            public const string ActivatedSuccessfully = "Api.Car.Activated.Successful";
            
            public const string AddMoreThanMaxNotAllowed = "Api.Car.AddMoreThanMax.NotAllowed";
        }
        public static class PetroStationMessage
        {
            public const string IdRequired = "Api.PetroStation.Id.Required";
            
            public const string PetroPayAccountIdRequired = "Api.PetroStation.PetroPayAccountId.Required";
            public const string AmountRequired = "Api.PetroStation.Amount.Required";
            public const string ReferenceRequired = "Api.PetroStation.Reference.Required";
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
            
            public const string AddedSuccessfully = "Api.Bundle.Add.Successful";
            public const string EditedSuccessfully = "Api.Bundle.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.Bundle.Archived.Successful";
            public const string DeletedSuccessfully = "Api.Bundle.Deleted.Successful";
            
            public const string ArchiveEntityEditNotAllowed = "Api.Bundle.ArchivedEntityEdit.NotAllowed";
            
        }
        public static class SubscriptionMessage
        {
            public const string CompanyIdRequired = "Api.Subscription.CompanyId.Required";
            public const string BundleIdRequired = "Api.Subscription.BundleId.Required";
            public const string IdRequired = "Api.Subscription.Id.Required";
            public const string SubscriptionCarIdsRequired = "Api.Subscription.SubscriptionCarIds.Required";
            public const string SubscriptionCostRequired = "Api.Subscription.SubscriptionCost.Required";
            public const string SubscriptionCarNumberRequired = "Api.Subscription.SubscriptionCarNumbers.Required";
            public const string SubscriptionStartDateRequired = "Api.Subscription.SubscriptionStartDate.Required";
            public const string SubscriptionEndDateRequired = "Api.Subscription.SubscriptionEndDate.Required";
            public const string SubscriptionPaymentMethodRequired = "Api.Subscription.SubscriptionPaymentMethod.Required";
            
            public const string AddedSuccessfully = "Api.Subscription.Add.Successful";
            public const string EditedSuccessfully = "Api.Subscription.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Subscription.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Subscription.Deleted.Successful";
            public const string RejectedSuccessfully = "Api.Subscription.Rejected.Successful";
            public const string CarsAddedSuccessfully = "Api.Subscription.CarsAdded.Successful";
            
            public const string ActiveEntityEditNotAllowed = "Api.Subscription.ActiveEntityEdit.NotAllowed";
            public const string ActiveEntityDeleteNotAllowed = "Api.Subscription.ActiveEntityDelete.NotAllowed";
            public const string ActiveEntityRejectNotAllowed = "Api.Subscription.ActiveEntityReject.NotAllowed";
            public const string SubscriptionCarAddNotAllowed = "Api.Subscription.SubscriptionCarAdd.NotAllowed";
            public const string CarAddMoreNotAllowed = "Api.Subscription.CarAddMore.NotAllowed";
            
            public const string MoreThan1Month = "Api.Subscription.MoreThan1Month";
            public const string MoreThan1Year = "Api.Subscription.MoreThan1Year";
            
            
        }
        public static class RechargeBalanceMessage
        {
            public const string CompanyIdRequired = "Api.RechargeBalance.CompanyId.Required";
            public const string IdRequired = "Api.RechargeBalance.Id.Required";
            public const string NameRequired = "Api.RechargeBalance.Name.Required";
            public const string EmailRequired = "Api.RechargeBalance.Email.Required";
            public const string LogoRequired = "Api.RechargeBalance.Logo.Required";
            public const string EmailIsDuplicate = "Api.RechargeBalance.Email.Duplicate";
            public const string EmailIsWrong = "Api.RechargeBalance.Email.IsWrong";
            
            public const string AddedSuccessfully = "Api.RechargeBalance.Add.Successful";
            public const string EditedSuccessfully = "Api.RechargeBalance.Edit.Successful";
            public const string ConfirmedSuccessfully = "Api.RechargeBalance.Confirmed.Successful";
            public const string DeletedSuccessfully = "Api.RechargeBalance.Deleted.Successful";
            
            public const string ConfirmedEntityEditNotAllowed = "Api.RechargeBalance.ConfirmedEntityEdit.NotAllowed";
            
        }
        public static class TransferBalanceMessage
        {
            public const string TransferBalanceTypeRequired = "Api.TransferBalance.TransferBalanceType.Required";
            public const string CarIdsRequired = "Api.TransferBalance.CarIds.Required";
            public const string AmountRequired = "Api.TransferBalance.Amount.Required";
            public const string BranchIdRequired = "Api.TransferBalance.BranchId.Required";
            
            public const string AddedSuccessfully = "Api.TransferBalance.Add.Successful";
            public const string CarBatchedSuccessfully = "Api.TransferBalance.CarBatch.Successful";
            
            public const string ConfirmedEntityEditNotAllowed = "Api.TransferBalance.ConfirmedEntityEdit.NotAllowed";
            
        }
        public static class TransferBonusMessage
        {
            public const string AmountRequired = "Api.TransferBonus.Amount.Required";
            
            public const string AddedSuccessfully = "Api.TransferBonus.Add.Successful";
        }
        
        public static class PetropayAccountMessage
        {
            public const string FromPetroPayAccountIdRequired = "Api.PetropayAccount.FromPetroPayAccountId.Required";
            public const string ToPetroPayAccountIdRequired = "Api.PetropayAccount.ToPetroPayAccountId.Required";
            public const string PetroPayAccountsNotEqual = "Api.PetropayAccount.PetroPayAccounts.NotEqual";
            public const string AmountRequired = "Api.PetropayAccount.Amount.Required";
            public const string ReferenceRequired = "Api.PetropayAccount.Reference.Required";
            
            public const string AddedSuccessfully = "Api.PetropayAccount.Add.Successful";
            
            public const string ConfirmedEntityEditNotAllowed = "Api.PetropayAccount.ConfirmedEntityEdit.NotAllowed";
            
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
        
        public static class PromotionCouponMessage
        {
            public const string IdRequired = "Api.PromotionCoupon.Id.Required";
            
            public const string AddedSuccessfully = "Api.PromotionCoupon.Add.Successful";
            public const string EditedSuccessfully = "Api.PromotionCoupon.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.PromotionCoupon.Archived.Successful";
            public const string DeletedSuccessfully = "Api.PromotionCoupon.Deleted.Successful";
            
            public const string StartDateShouldBeLessThanEndDate = "Api.PromotionCoupon.StartDateShouldBeLessThanEndDate";
        }
        
        
        public static class AppSettingMessage
        {
            public const string IdRequired = "Api.AppSetting.Id.Required";
            
            public const string AddedSuccessfully = "Api.AppSetting.Add.Successful";
            public const string EditedSuccessfully = "Api.AppSetting.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.AppSetting.Archived.Successful";
            public const string DeletedSuccessfully = "Api.AppSetting.Deleted.Successful";
            
        }
        public static class OdometerRecordMessage
        {
            public const string IdRequired = "Api.OdometerRecord.Id.Required";
            
            public const string AddedSuccessfully = "Api.OdometerRecord.Add.Successful";
            public const string EditedSuccessfully = "Api.OdometerRecord.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.OdometerRecord.Archived.Successful";
            public const string DeletedSuccessfully = "Api.OdometerRecord.Deleted.Successful";
            
            public const string AtLeastOneMonth = "Api.OdometerRecord.AtLeastOneMonth";
            public const string NewRecordShouldBeGreaterThanPreviousRecord = "Api.OdometerRecord.NewRecordShouldBeGreaterThanPreviousRecord";
            
        }
        public static class MenuMessage
        {
            public const string IdRequired = "Api.Menu.Id.Required";
            
            public const string AddedSuccessfully = "Api.Menu.Add.Successful";
            public const string EditedSuccessfully = "Api.Menu.Edit.Successful";
            public const string DeletedSuccessfully = "Api.Menu.Deleted.Successful";
            public const string ActivatedSuccessfully = "Api.Menu.Activated.Successful";
        }
        public static class EmplyeeMessage
        {
            public const string IdRequired = "Api.Employee.Id.Required";
            
            public const string AddedSuccessfully = "Api.Employee.Add.Successful";
            public const string EditedSuccessfully = "Api.Employee.Edit.Successful";
            public const string DeletedSuccessfully = "Api.Employee.Deleted.Successful";
            public const string ActivatedSuccessfully = "Api.Employee.Activated.Successful";
            
            
        }
        
        public static class EmployeeMenuMessage
        {
            public const string IdRequired = "Api.EmployeeMenu.Id.Required";
            
            public const string AddedSuccessfully = "Api.EmployeeMenu.Add.Successful";
        }
        
        public static class NewCustomerMessage
        {
            public const string IdRequired = "Api.NewCustomer.Id.Required";
            
            public const string AddedSuccessfully = "Api.NewCustomer.Add.Successful";
            public const string EditedSuccessfully = "Api.NewCustomer.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.NewCustomer.Archived.Successful";
            public const string DeletedSuccessfully = "Api.NewCustomer.Deleted.Successful";
            public const string ActivatedSuccessfully = "Api.NewCustomer.Activated.Successful";
            
        }
    }
}
