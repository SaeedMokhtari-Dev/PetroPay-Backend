namespace PetroPay.Web.Configuration.Constants
{
    public static class Endpoints
    {
        #region Auth
        /*Auth APIs*/
        public const string ApiAuthLogin = "/api/auth/login";
        public const string ApiAuthResetPassword = "/api/auth/reset-password";
        public const string ApiAuthValidateResetPasswordToken = "/api/auth/validate-reset-password-token";
        public const string ApiAuthChangePassword = "/api/auth/change-password";
        public const string ApiAuthChangeUserPassword = "/api/auth/change-user-password";
        public const string ApiAuthLogout = "/api/auth/logout";
        public const string ApiAuthCheck = "/api/auth/check";
        public const string ApiAuthRefreshAccessToken = "/api/auth/refresh-access-token";
        public const string ApiUserInfo = "/api/user/info";
        
        /*admin APIs*/
        public const string ApiUserGet = "/api/user/get";
        public const string ApiUserAdd = "/api/user/add";
        public const string ApiUserEdit = "/api/user/edit";
        public const string ApiUserDetail = "/api/user/detail";
        
        #endregion

        #region Entities

        /*Company APIs*/
        public const string ApiCompanyAdd = "/api/company/add";
        public const string ApiCompanyEdit = "/api/company/edit";
        public const string ApiCompanyGet = "/api/company/get";
        public const string ApiCompanyDetail = "/api/company/detail";
        public const string ApiCompanyDelete = "/api/company/delete";
        public const string ApiCompanyList = "/api/company/list";
        
        /*Branch APIs*/
        public const string ApiBranchAdd = "/api/branch/add";
        public const string ApiBranchEdit = "/api/branch/edit";
        public const string ApiBranchGet = "/api/branch/get";
        public const string ApiBranchList = "/api/branch/list";
        public const string ApiBranchDetail = "/api/branch/detail";
        public const string ApiBranchDelete = "/api/branch/delete";
        public const string ApiBranchActive = "/api/branch/active";
        public const string ApiBranchChargeBalance = "/api/branch/charge-balance";
        
        /*Bundle APIs*/
        public const string ApiBundleAdd = "/api/bundle/add";
        public const string ApiBundleEdit = "/api/bundle/edit";
        public const string ApiBundleGet = "/api/bundle/get";
        public const string ApiBundleDetail = "/api/bundle/detail";
        public const string ApiBundleDelete = "/api/bundle/delete";
        
        
        /*PetroStation APIs*/
        public const string ApiPetroStationAdd = "/api/petro-station/add";
        public const string ApiPetroStationEdit = "/api/petro-station/edit";
        public const string ApiPetroStationGet = "/api/petro-station/get";
        public const string ApiPetroStationDetail = "/api/petro-station/detail";
        public const string ApiPetroStationDelete = "/api/petro-station/delete";
        public const string ApiPetroStationPayment = "/api/petro-station/payment";
        public const string ApiPetroStationList = "/api/petro-station/list";
        
        /*StationUser APIs*/
        public const string ApiStationUserAdd = "/api/station-user/add";
        public const string ApiStationUserEdit = "/api/station-user/edit";
        public const string ApiStationUserGet = "/api/station-user/get";
        public const string ApiStationUserDetail = "/api/station-user/detail";
        public const string ApiStationUserDelete = "/api/station-user/delete";
        
        /*Car APIs*/
        public const string ApiCarAdd = "/api/car/add";
        public const string ApiCarEdit = "/api/car/edit";
        public const string ApiCarGet = "/api/car/get";
        public const string ApiCarDetail = "/api/car/detail";
        public const string ApiCarDelete = "/api/car/delete";
        public const string ApiCarList = "/api/car/list";
        public const string ApiCarActive = "/api/car/active";
        
        /*Subscription APIs*/
        public const string ApiSubscriptionAdd = "/api/subscription/add";
        public const string ApiSubscriptionEdit = "/api/subscription/edit";
        public const string ApiSubscriptionGet = "/api/subscription/get";
        public const string ApiSubscriptionDetail = "/api/subscription/detail";
        public const string ApiSubscriptionDelete = "/api/subscription/delete";
        public const string ApiSubscriptionActive = "/api/subscription/active";
        public const string ApiSubscriptionCalculate = "/api/subscription/calculate";
        public const string ApiSubscriptionCarAdd = "/api/subscription/car-add";
        
        /*RechargeBalance APIs*/
        public const string ApiRechargeBalanceAdd = "/api/recharge-balance/add";
        public const string ApiRechargeBalanceEdit = "/api/recharge-balance/edit";
        public const string ApiRechargeBalanceGet = "/api/recharge-balance/get";
        public const string ApiRechargeBalanceDetail = "/api/recharge-balance/detail";
        public const string ApiRechargeBalanceDelete = "/api/recharge-balance/delete";
        public const string ApiRechargeBalanceConfirm = "/api/recharge-balance/confirm";
        
        public const string ApiPetropayAccountGet = "/api/petropay-account/get";
        public const string ApiPetropayAccountList = "/api/petropay-account/list";
        public const string ApiPetropayAccountPayment = "/api/petropay-account/payment";
        
        public const string ApiServiceMasterList = "/api/service-master/list";
        
        public const string ApiTransferBalance = "/api/transfer-balance";
        
        
        /*PromotionCoupon APIs*/
        public const string ApiPromotionCouponAdd = "/api/promotion-coupon/add";
        public const string ApiPromotionCouponEdit = "/api/promotion-coupon/edit";
        public const string ApiPromotionCouponGet = "/api/promotion-coupon/get";
        public const string ApiPromotionCouponDetail = "/api/promotion-coupon/detail";
        public const string ApiPromotionCouponDelete = "/api/promotion-coupon/delete";
        
        /*AppSetting APIs*/
        public const string ApiAppSettingAdd = "/api/app-setting/add";
        public const string ApiAppSettingEdit = "/api/app-setting/edit";
        public const string ApiAppSettingGet = "/api/app-setting/get";
        public const string ApiAppSettingDetail = "/api/app-setting/detail";
        public const string ApiAppSettingDelete = "/api/app-setting/delete";
        
        /*OdometerRecord APIs*/
        public const string ApiOdometerRecordAdd = "/api/odometer-record/add";
        public const string ApiOdometerRecordEdit = "/api/odometer-record/edit";
        public const string ApiOdometerRecordGet = "/api/odometer-record/get";
        public const string ApiOdometerRecordDetail = "/api/odometer-record/detail";
        public const string ApiOdometerRecordDelete = "/api/odometer-record/delete";
        
        /*Menu APIs*/
        public const string ApiMenuAdd = "/api/menu/add";
        public const string ApiMenuEdit = "/api/menu/edit";
        public const string ApiMenuGet = "/api/menu/get";
        public const string ApiMenuDetail = "/api/menu/detail";
        public const string ApiMenuDelete = "/api/menu/delete";
        public const string ApiMenuList = "/api/menu/list";
        public const string ApiMenuActive = "/api/menu/active";
        public const string ApiMenuTree = "/api/menu/tree";
        
        /*Emplyee APIs*/
        public const string ApiEmplyeeAdd = "/api/employee/add";
        public const string ApiEmplyeeEdit = "/api/employee/edit";
        public const string ApiEmplyeeGet = "/api/employee/get";
        public const string ApiEmplyeeDetail = "/api/employee/detail";
        public const string ApiEmplyeeDelete = "/api/employee/delete";
        public const string ApiEmplyeeList = "/api/employee/list";
        public const string ApiEmplyeeActive = "/api/employee/active";
        
        
        
        /*EmployeeMenu APIs*/
        public const string ApiEmployeeMenuAdd = "/api/employee-menu/add";
        public const string ApiEmployeeMenuDetail = "/api/employee-menu/detail";
        public const string ApiEmployeeMenuTree = "/api/employee-menu/tree";
        #endregion

        #region Reports

        /*AccountBalance APIs*/
        public const string ApiAccountBalanceGet = "/api/account-balance/get";
        public const string ApiAccountBalanceDetail = "/api/account-balance/detail";
        
        /*InvoiceSummary APIs*/
        public const string ApiInvoiceSummaryGet = "/api/invoice-summary/get";
        /*InvoiceDetails APIs*/
        public const string ApiInvoiceDetailGet = "/api/invoice-detail/get";
        /*CarBalances APIs*/
        public const string ApiCarBalanceGet = "/api/car-balance/get";
        /*CarTransactions APIs*/
        public const string ApiCarTransactionGet = "/api/car-transaction/get";
        /*StationReports APIs*/
        public const string ApiStationReportGet = "/api/station-report/get";
        /*StationSales APIs*/
        public const string ApiStationSaleGet = "/api/station-sale/get";
        /*StationStatements APIs*/
        public const string ApiStationStatementGet = "/api/station-statement/get";
        /*PetrolStationLists APIs*/
        public const string ApiPetrolStationListGet = "/api/petrol-station-list/get";
        /*CarConsumptionRates APIs*/
        public const string ApiCarConsumptionRateGet = "/api/car-consumption-rate/get";
        /*CarKmConsumptions APIs*/
        public const string ApiCarKmConsumptionGet = "/api/car-km-consumption/get";
        /*CarOdometerMaxes APIs*/
        public const string ApiCarOdometerMaxGet = "/api/car-odometer-max/get";
        /*CarOdometerMins APIs*/
        public const string ApiCarOdometerMinGet = "/api/car-odometer-min/get";
        /*OdometerBetweenDates APIs*/
        public const string ApiOdometerBetweenDateGet = "/api/odometer-between-date/get";

        #endregion

        #region Dashboards

        public const string ApiDashboardCustomerGet = "/api/dashboard/customer";
        public const string ApiDashboardSupplierGet = "/api/dashboard/supplier";
        public const string ApiDashboardAdminGet = "/api/dashboard/admin";
        

        #endregion
        
        public const string ApiLog = "/api/log";
        public const string Swagger = "/swagger/v1/swagger.json";
    }
}
