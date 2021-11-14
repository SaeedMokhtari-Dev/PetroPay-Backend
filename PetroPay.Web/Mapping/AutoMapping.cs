using System;
using System.Globalization;
using System.Runtime.Serialization;
using AutoMapper;
using Itenso.TimePeriod;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.AppSettings.Add;
using PetroPay.Web.Controllers.Entities.AppSettings.Detail;
using PetroPay.Web.Controllers.Entities.AppSettings.Edit;
using PetroPay.Web.Controllers.Entities.Branches.Add;
using PetroPay.Web.Controllers.Entities.Branches.Detail;
using PetroPay.Web.Controllers.Entities.Branches.Edit;
using PetroPay.Web.Controllers.Entities.Branches.Get;
using PetroPay.Web.Controllers.Entities.Bundles.Add;
using PetroPay.Web.Controllers.Entities.Bundles.Detail;
using PetroPay.Web.Controllers.Entities.Bundles.Edit;
using PetroPay.Web.Controllers.Entities.Bundles.Get;
using PetroPay.Web.Controllers.Entities.Cars.Add;
using PetroPay.Web.Controllers.Entities.Cars.Detail;
using PetroPay.Web.Controllers.Entities.Cars.Edit;
using PetroPay.Web.Controllers.Entities.Cars.Get;
using PetroPay.Web.Controllers.Entities.Companies.Add;
using PetroPay.Web.Controllers.Entities.Companies.Detail;
using PetroPay.Web.Controllers.Entities.Companies.Edit;
using PetroPay.Web.Controllers.Entities.Companies.Get;
using PetroPay.Web.Controllers.Entities.Emplyees.Add;
using PetroPay.Web.Controllers.Entities.Emplyees.Detail;
using PetroPay.Web.Controllers.Entities.Emplyees.Edit;
using PetroPay.Web.Controllers.Entities.Emplyees.Get;
using PetroPay.Web.Controllers.Entities.Menus.Add;
using PetroPay.Web.Controllers.Entities.Menus.Detail;
using PetroPay.Web.Controllers.Entities.Menus.Edit;
using PetroPay.Web.Controllers.Entities.Menus.Get;
using PetroPay.Web.Controllers.Entities.NewCustomers.Add;
using PetroPay.Web.Controllers.Entities.NewCustomers.Detail;
using PetroPay.Web.Controllers.Entities.NewCustomers.Edit;
using PetroPay.Web.Controllers.Entities.NewCustomers.Get;
using PetroPay.Web.Controllers.Entities.OdometerRecords.Add;
using PetroPay.Web.Controllers.Entities.OdometerRecords.Detail;
using PetroPay.Web.Controllers.Entities.OdometerRecords.Edit;
using PetroPay.Web.Controllers.Entities.OdometerRecords.Get;
using PetroPay.Web.Controllers.Entities.PetrolCompanies.Add;
using PetroPay.Web.Controllers.Entities.PetrolCompanies.Detail;
using PetroPay.Web.Controllers.Entities.PetrolCompanies.Edit;
using PetroPay.Web.Controllers.Entities.PetrolCompanies.Get;
using PetroPay.Web.Controllers.Entities.PetropayAccounts.Get;
using PetroPay.Web.Controllers.Entities.PetroStations.Add;
using PetroPay.Web.Controllers.Entities.PetroStations.Detail;
using PetroPay.Web.Controllers.Entities.PetroStations.Edit;
using PetroPay.Web.Controllers.Entities.PetroStations.Get;
using PetroPay.Web.Controllers.Entities.PromotionCoupons.Add;
using PetroPay.Web.Controllers.Entities.PromotionCoupons.Detail;
using PetroPay.Web.Controllers.Entities.PromotionCoupons.Edit;
using PetroPay.Web.Controllers.Entities.PromotionCoupons.Get;
using PetroPay.Web.Controllers.Entities.RechargeBalances.Add;
using PetroPay.Web.Controllers.Entities.RechargeBalances.Detail;
using PetroPay.Web.Controllers.Entities.RechargeBalances.Edit;
using PetroPay.Web.Controllers.Entities.RechargeBalances.Get;
using PetroPay.Web.Controllers.Entities.StationUsers.Add;
using PetroPay.Web.Controllers.Entities.StationUsers.Detail;
using PetroPay.Web.Controllers.Entities.StationUsers.Edit;
using PetroPay.Web.Controllers.Entities.StationUsers.Get;
using PetroPay.Web.Controllers.Entities.Subscriptions.Add;
using PetroPay.Web.Controllers.Entities.Subscriptions.Detail;
using PetroPay.Web.Controllers.Entities.Subscriptions.Edit;
using PetroPay.Web.Controllers.Entities.Subscriptions.Get;
using PetroPay.Web.Controllers.Entities.TransferBonuses.Get;
using PetroPay.Web.Controllers.Reports.AccountBalances.Get;
using PetroPay.Web.Controllers.Reports.CarBalances.Get;
using PetroPay.Web.Controllers.Reports.CarConsumptionRates.Get;
using PetroPay.Web.Controllers.Reports.CarKmConsumptions.Get;
using PetroPay.Web.Controllers.Reports.CarOdometerMaxes.Get;
using PetroPay.Web.Controllers.Reports.CarOdometerMins.Get;
using PetroPay.Web.Controllers.Reports.CarTransactions.Get;
using PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get;
using PetroPay.Web.Controllers.Reports.CustomerStatements.Get;
using PetroPay.Web.Controllers.Reports.InvoiceDetails.Get;
using PetroPay.Web.Controllers.Reports.InvoiceSummary.Get;
using PetroPay.Web.Controllers.Reports.OdometerBetweenDates.Get;
using PetroPay.Web.Controllers.Reports.OdometerHistories.Get;
using PetroPay.Web.Controllers.Reports.PetrolStationLists.Get;
using PetroPay.Web.Controllers.Reports.StationReports.Get;
using PetroPay.Web.Controllers.Reports.StationSales.Get;
using PetroPay.Web.Controllers.Reports.StationStatements.Get;
using PetroPay.Web.Extensions;
using TestScaffold.Models;

namespace PetroPay.Web.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            #region Entities

            #region Company
            
            CreateMap<Company, CompanyGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.CompanyId));
            CreateMap<Company, CompanyDetailResponse>()
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.CompanyTaxPhoto,
                    opt => opt.MapFrom(e => $"data:image/png;base64,{e.CompanyTaxPhoto}"))
                .ForMember(w => w.CompanyVatPhoto,
                    opt => opt.MapFrom(e => $"data:image/png;base64,{e.CompanyVatPhoto}"));
            CreateMap<CompanyEditRequest, Company>()
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore())
                .ForMember(w => w.CompanyVatPhoto,
                    opt => opt.MapFrom(e => e.CompanyVatPhoto.Remove(0, e.CompanyVatPhoto.IndexOf(',') + 1)))
                .ForMember(w => w.CompanyTaxPhoto,
                    opt => opt.MapFrom(e => e.CompanyTaxPhoto.Remove(0, e.CompanyTaxPhoto.IndexOf(',') + 1)));
            CreateMap<CompanyAddRequest, Company>()
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.CompanyVatPhoto,
                    opt => opt.MapFrom(e => e.CompanyVatPhoto.Remove(0, e.CompanyVatPhoto.IndexOf(',') + 1)))
                .ForMember(w => w.CompanyTaxPhoto,
                    opt => opt.MapFrom(e => e.CompanyTaxPhoto.Remove(0, e.CompanyTaxPhoto.IndexOf(',') + 1)));
            
            #endregion
            #region PetrolCompany
            
            CreateMap<PetrolCompany, PetrolCompanyGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.PetrolCompanyId));
            CreateMap<PetrolCompany, PetrolCompanyDetailResponse>()
                .ForMember(w => w.PetrolCompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.PetrolCompanyTaxPhoto,
                    opt => opt.MapFrom(e => $"data:image/png;base64,{e.PetrolCompanyTaxPhoto}"))
                .ForMember(w => w.PetrolCompanyVatPhoto,
                    opt => opt.MapFrom(e => $"data:image/png;base64,{e.PetrolCompanyVatPhoto}"));
            CreateMap<PetrolCompanyEditRequest, PetrolCompany>()
                .ForMember(w => w.PetrolCompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.PetrolCompanyId, opt => opt.Ignore())
                .ForMember(w => w.PetrolCompanyVatPhoto,
                    opt => opt.MapFrom(e => e.PetrolCompanyVatPhoto.Remove(0, e.PetrolCompanyVatPhoto.IndexOf(',') + 1)))
                .ForMember(w => w.PetrolCompanyTaxPhoto,
                    opt => opt.MapFrom(e => e.PetrolCompanyTaxPhoto.Remove(0, e.PetrolCompanyTaxPhoto.IndexOf(',') + 1)));
            CreateMap<PetrolCompanyAddRequest, PetrolCompany>()
                .ForMember(w => w.PetrolCompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.PetrolCompanyVatPhoto,
                    opt => opt.MapFrom(e => e.PetrolCompanyVatPhoto.Remove(0, e.PetrolCompanyVatPhoto.IndexOf(',') + 1)))
                .ForMember(w => w.PetrolCompanyTaxPhoto,
                    opt => opt.MapFrom(e => e.PetrolCompanyTaxPhoto.Remove(0, e.PetrolCompanyTaxPhoto.IndexOf(',') + 1)));
            
            #endregion
            #region Branch
            
            CreateMap<CompanyBranch, BranchGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.CompanyBranchId));
            CreateMap<CompanyBranch, BranchDetailResponse>();
            CreateMap<BranchEditRequest, CompanyBranch>()
                .ForMember(w => w.CompanyBranchId, opt => opt.Ignore());
            CreateMap<BranchAddRequest, CompanyBranch>();
            
            #endregion
            #region Car

            CreateMap<Car, CarGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.CarId))
                .ForMember(w => w.CompanyBarnchName, opt => opt.MapFrom(e => e.CompanyBarnchId.HasValue ? e.CompanyBarnch.CompanyBranchName : string.Empty))
                .ForMember(w => w.CompanyName, opt => opt.MapFrom(e => e.CompanyBarnchId.HasValue ? (e.CompanyBarnch.CompanyId.HasValue ? e.CompanyBarnch.Company.CompanyName : string.Empty) : string.Empty));
            CreateMap<Car, CarDetailResponse>()
                .ForMember(w => w.CarPlatePhoto, opt => opt.MapFrom(e => $"data:image/png;base64,{e.CarPlatePhoto}"));
            CreateMap<CarEditRequest, Car>()
                .ForMember(w => w.CarId, opt => opt.Ignore())
                .ForMember(w => w.CarPlatePhoto, opt => opt.MapFrom(e => e.CarPlatePhoto.Remove(0, e.CarPlatePhoto.IndexOf(',') + 1)));
            CreateMap<CarAddRequest, Car>()
                .ForMember(w => w.CarPlatePhoto, opt => opt.MapFrom(e => e.CarPlatePhoto.Remove(0, e.CarPlatePhoto.IndexOf(',') + 1)));
            
            #endregion
            #region Subscription

            CreateMap<Subscription, SubscriptionGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.SubscriptionId))
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")))
                .ForMember(w => w.SubscriptionStartDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionStartDate.HasValue
                            ? e.SubscriptionStartDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.SubscriptionEndDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionEndDate.HasValue
                            ? e.SubscriptionEndDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.SubscriptionDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionDate.HasValue
                            ? e.SubscriptionDate.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : string.Empty))
                .ForMember(w => w.Expired,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionEndDate < DateTime.Now.GetEgyptDateTime()));
            CreateMap<Subscription, SubscriptionDetailResponse>()
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.CompanyId.HasValue ? e.Company.CompanyName : "")))
                .ForMember(w => w.PayFromCompanyBalance,
                    opt => opt.MapFrom(e => e.SubscriptionPaymentMethod == "CompanyBalance"))
                .ForMember(w => w.SubscriptionStartDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionStartDate.HasValue
                            ? e.SubscriptionStartDate.Value.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.SubscriptionEndDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionEndDate.HasValue
                            ? e.SubscriptionEndDate.Value.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.SubscriptionDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionDate.HasValue
                            ? e.SubscriptionDate.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : string.Empty));
            CreateMap<SubscriptionEditRequest, Subscription>()
                .ForMember(w => w.SubscriptionId, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore())
                .ForMember(w => w.SubscriptionStartDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.SubscriptionStartDate,
                        DateTimeConstants.DateFormat, CultureInfo.InvariantCulture)))
                .ForMember(w => w.SubscriptionEndDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.SubscriptionEndDate, DateTimeConstants.DateFormat,
                        CultureInfo.InvariantCulture)));
            CreateMap<SubscriptionAddRequest, Subscription>()
                .ForMember(w => w.SubscriptionDate, opt => opt.MapFrom(src => DateTime.Now.GetEgyptDateTime()))
                .ForMember(w => w.SubscriptionStartDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.SubscriptionStartDate,
                        DateTimeConstants.DateFormat, CultureInfo.InvariantCulture)))
                .ForMember(w => w.SubscriptionEndDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.SubscriptionEndDate, DateTimeConstants.DateFormat,
                        CultureInfo.InvariantCulture)));
            
            #endregion
            #region RechargeBalance

            CreateMap<RechargeBalance, RechargeBalanceGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.RechargeId))
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")))
                .ForMember(w => w.BankTransactionDate,
                    opt => opt.MapFrom(e =>
                        e.BankTransactionDate.HasValue
                            ? e.BankTransactionDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.RechageDate,
                    opt => opt.MapFrom(e =>
                        e.RechageDate.HasValue
                            ? e.RechageDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty));
            
            CreateMap<RechargeBalance, RechargeBalanceDetailResponse>()
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")))
                .ForMember(w => w.BankTransactionDate,
                    opt => opt.MapFrom(e => e.BankTransactionDate.HasValue ? 
                        e.BankTransactionDate.Value.Date.ToString(DateTimeConstants.DateFormat) : string.Empty))
                .ForMember(w => w.RechageDate,
                    opt => opt.MapFrom(e => e.RechageDate.HasValue ? 
                        e.RechageDate.Value.ToString(DateTimeConstants.DateTimeFormat) : string.Empty))
                .ForMember(w => w.RechargeDocumentPhoto, opt => 
                    opt.MapFrom(e => $"data:image/png;base64,{e.RechargeDocumentPhoto}"));
            
            CreateMap<RechargeBalanceEditRequest, RechargeBalance>()
                .ForMember(w => w.RechargeId, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore())
                .ForMember(w => w.BankTransactionDate,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.BankTransactionDate) ? DateTime.ParseExact(src.BankTransactionDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture) : default))
                .ForMember(w => w.RechargeDocumentPhoto, opt => 
                    opt.MapFrom(e => e.RechargeDocumentPhoto.Remove(0, e.RechargeDocumentPhoto.IndexOf(',') + 1)));
            
            CreateMap<RechargeBalanceAddRequest, RechargeBalance>()
                .ForMember(w => w.RechageDate, opt => opt.MapFrom(src => DateTime.Now.GetEgyptDateTime()))
                .ForMember(w => w.BankTransactionDate,
                    opt => opt.MapFrom(src => 
                        !string.IsNullOrEmpty(src.BankTransactionDate) ? DateTime.ParseExact(src.BankTransactionDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture) : default))
                .ForMember(w => w.RechargeDocumentPhoto, opt => 
                    opt.MapFrom(e => e.RechargeDocumentPhoto.Remove(0, e.RechargeDocumentPhoto.IndexOf(',') + 1)));
            
            #endregion
            #region PetroStation
            
            CreateMap<PetroStation, PetroStationGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.StationId))
                .ForMember(w => w.PetrolCompanyName, opt 
                    => opt.MapFrom(e => e.PetrolCompanyId.HasValue ? e.PetrolCompany.PetrolCompanyName : string.Empty));
            CreateMap<PetroStation, PetroStationDetailResponse>()
                .ForMember(w => w.PetrolCompanyName, opt
                    => opt.MapFrom(e => e.PetrolCompanyId.HasValue ? e.PetrolCompany.PetrolCompanyName : string.Empty));
            CreateMap<PetroStationEditRequest, PetroStation>()
                .ForMember(w => w.StationId, opt => opt.Ignore());
            CreateMap<PetroStationAddRequest, PetroStation>();
            
            #endregion
            #region StationUser
            
            CreateMap<StationUser, StationUserGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.StationWorkerId));
            CreateMap<StationUser, StationUserDetailResponse>();
            CreateMap<StationUserEditRequest, StationUser>()
                .ForMember(w => w.StationWorkerId, opt => opt.Ignore());
            CreateMap<StationUserAddRequest, StationUser>();
            
            #endregion
            #region Bundle
            
            CreateMap<Bundle, BundleGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.BundlesId));
            CreateMap<Bundle, BundleDetailResponse>();
            CreateMap<BundleEditRequest, Bundle>()
                .ForMember(w => w.BundlesId, opt => opt.Ignore());
            CreateMap<BundleAddRequest, Bundle>();
            
            #endregion

            #region TransAccount
            CreateMap<TransAccount, PetropayAccountGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.TransId))
                .ForMember(w => w.AccountName,
                    opt => opt.MapFrom(e => e.AccountId.HasValue ? e.Account.AccountName : ""))
                .ForMember(w => w.TransDate, opt =>
                    opt.MapFrom(e =>
                        e.TransDate.HasValue
                            ? e.TransDate.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            CreateMap<TransAccount, TransferBonusGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.TransId))
                .ForMember(w => w.AccountName,
                    opt => opt.MapFrom(e => e.AccountId.HasValue ? e.Account.AccountName : ""))
                .ForMember(w => w.TransDate, opt =>
                    opt.MapFrom(e =>
                        e.TransDate.HasValue
                            ? e.TransDate.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            #endregion
            #region PromotionCoupon

            CreateMap<PromotionCoupon, PromotionCouponGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.CouponId))
                .ForMember(w => w.CouponActiveDate, opt =>
                    opt.MapFrom(e =>
                        e.CouponActiveDate.HasValue ? e.CouponActiveDate.Value.Date.ToString(DateTimeConstants.DateFormat) : ""))
                .ForMember(w => w.CouponEndDate, opt =>
                    opt.MapFrom(e =>
                        e.CouponEndDate.HasValue ? e.CouponEndDate.Value.Date.ToString(DateTimeConstants.DateFormat) : ""));
                
            CreateMap<PromotionCoupon, PromotionCouponDetailResponse>()
                .ForMember(w => w.CouponActiveDate, opt =>
                    opt.MapFrom(e =>
                        e.CouponActiveDate.HasValue ? e.CouponActiveDate.Value.Date.ToString(DateTimeConstants.DateFormat) : ""))
                .ForMember(w => w.CouponEndDate, opt =>
                    opt.MapFrom(e =>
                        e.CouponEndDate.HasValue ? e.CouponEndDate.Value.Date.ToString(DateTimeConstants.DateFormat) : ""));
            CreateMap<PromotionCouponEditRequest, PromotionCoupon>()
                .ForMember(w => w.CouponId, opt => opt.Ignore())
                .ForMember(w => w.CouponActiveDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.CouponActiveDate)
                            ? DateTime.ParseExact(e.CouponActiveDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default))
                .ForMember(w => w.CouponEndDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.CouponEndDate)
                            ? DateTime.ParseExact(e.CouponEndDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default));
            CreateMap<PromotionCouponAddRequest, PromotionCoupon>().ForMember(w => w.CouponActiveDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.CouponActiveDate)
                            ? DateTime.ParseExact(e.CouponActiveDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default))
                .ForMember(w => w.CouponEndDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.CouponEndDate)
                            ? DateTime.ParseExact(e.CouponEndDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default));
            
            #endregion
            
            #region AppSetting

            CreateMap<AppSetting, AppSettingDetailResponse>()
                .ForMember(w => w.CompanyLogo, opt =>
                    opt.MapFrom(e => $"data:image/png;base64,{e.CompanyLogo}"))
                .ForMember(w => w.CompanyStampImage, opt =>
                    opt.MapFrom(e => $"data:image/png;base64,{e.CompanyStampImage}"));
            CreateMap<AppSettingEditRequest, AppSetting>()
                .ForMember(w => w.Id, opt =>
                    opt.Ignore())
                .ForMember(w => w.CompanyLogo, opt =>
                    opt.MapFrom(e => e.CompanyLogo.Remove(0, e.CompanyLogo.IndexOf(',') + 1)))
                .ForMember(w => w.CompanyStampImage, opt =>
                    opt.MapFrom(e => e.CompanyStampImage.Remove(0, e.CompanyStampImage.IndexOf(',') + 1)));
            CreateMap<AppSettingAddRequest, AppSetting>()
                .ForMember(w => w.CompanyLogo, opt =>
                    opt.MapFrom(e => e.CompanyLogo.Remove(0, e.CompanyLogo.IndexOf(',') + 1)))
                .ForMember(w => w.CompanyStampImage, opt =>
                    opt.MapFrom(e => e.CompanyStampImage.Remove(0, e.CompanyStampImage.IndexOf(',') + 1)));
            
            #endregion
            
            #region OdometerRecord

            CreateMap<OdometerRecord, OdometerRecordGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.OdometerRecordId))
                .ForMember(w => w.CarIdNumber, opt =>
                    opt.MapFrom(e => e.CarId.HasValue ? e.Car.CarIdNumber : string.Empty))
                .ForMember(w => w.OdometerRecordDate, opt =>
                    opt.MapFrom(e =>
                        e.OdometerRecordDate.HasValue
                            ? e.OdometerRecordDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : ""));
            CreateMap<ViewOdometerRecord, OdometerRecordGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.OdometerRecordId))
                .ForMember(w => w.CarIdNumber, opt =>
                    opt.MapFrom(e => e.CarIdNumber))
                .ForMember(w => w.OdometerRecordDate, opt =>
                    opt.MapFrom(e =>
                        e.OdometerRecordDate.HasValue
                            ? e.OdometerRecordDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : ""));
            CreateMap<OdometerRecord, OdometerRecordDetailResponse>()
                .ForMember(w => w.OdometerRecordDate, opt =>
                    opt.MapFrom(e =>
                        e.OdometerRecordDate.HasValue
                            ? e.OdometerRecordDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : ""));
            CreateMap<OdometerRecordEditRequest, OdometerRecord>()
                .ForMember(w => w.OdometerRecordId, opt => opt.Ignore())
                .ForMember(w => w.OdometerRecordDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.OdometerRecordDate)
                            ? DateTime.ParseExact(e.OdometerRecordDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default));
            CreateMap<OdometerRecordAddRequest, OdometerRecord>()
                .ForMember(w => w.OdometerRecordDate, opt =>
                    opt.MapFrom(e =>
                        !string.IsNullOrEmpty(e.OdometerRecordDate)
                            ? DateTime.ParseExact(e.OdometerRecordDate, DateTimeConstants.DateFormat,
                                CultureInfo.InvariantCulture)
                            : default));
            
            #endregion
            
            
            #region Menu

            CreateMap<Menu, MenuGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.ParentTitleEn,
                    opt => opt.MapFrom(e => e.ParentId.HasValue ? e.Parent.EnTitle : string.Empty))
                .ForMember(w => w.ParentTitleAr,
                    opt => opt.MapFrom(e => e.ParentId.HasValue ? e.Parent.ArTitle : string.Empty))
                .ForMember(w => w.CreatedAt,
                    opt => opt.MapFrom(e => e.CreatedAt.ToString(DateTimeConstants.DateTimeFormat)));
            CreateMap<Menu, MenuDetailResponse>()
                .ForMember(w => w.MenuId, opt => opt.MapFrom(e => e.Id));
            CreateMap<MenuEditRequest, Menu>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.CreatedAt, opt => opt.Ignore());
            CreateMap<MenuAddRequest, Menu>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now.GetEgyptDateTime()));
            
            #endregion 
            #region Emplyee

            CreateMap<Emplyee, EmplyeeGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.EmplyeeId));
            CreateMap<Emplyee, EmplyeeDetailResponse>()
                .ForMember(w => w.EmplyeePhoto, opt =>
                    opt.Ignore());
            CreateMap<EmplyeeEditRequest, Emplyee>()
                .ForMember(w => w.EmplyeePhoto, opt =>
                    opt.Ignore());
            CreateMap<EmplyeeAddRequest, Emplyee>()
                .ForMember(w => w.EmplyeePhoto, opt =>
                    opt.Ignore());
            
            #endregion
            #region NewCustomer
            
            CreateMap<NewCustomer, NewCustomerGetResponseItem>()
                .ForMember(w => w.Key, opt => 
                    opt.MapFrom(e => e.CustReqId))
                .ForMember(w => w.CutReqDatetime, opt =>
                    opt.MapFrom(e =>
                        e.CutReqDatetime.HasValue
                            ? e.CutReqDatetime.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            CreateMap<NewCustomer, NewCustomerDetailResponse>();
            CreateMap<NewCustomerEditRequest, NewCustomer>()
                .ForMember(w => w.CustReqId, opt => opt.Ignore())
                .ForMember(w => w.CutReqDatetime, opt => opt.Ignore());
            CreateMap<NewCustomerAddRequest, NewCustomer>()
                .ForMember(w => w.CutReqDatetime, opt => opt.MapFrom(e => DateTime.Now.GetEgyptDateTime()));
            
            #endregion
            #endregion

            #region Reports

            CreateMap<ViewInvoicesSummary, InvoiceSummaryGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.InvoiceDataTime, opt =>
                    opt.MapFrom(e =>
                        e.InvoiceDataTime.HasValue
                            ? e.InvoiceDataTime.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            CreateMap<ViewCarBalance, CarBalanceGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.SubscriptionStartDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionStartDate.HasValue
                            ? e.SubscriptionStartDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty))
                .ForMember(w => w.SubscriptionEndDate,
                    opt => opt.MapFrom(e =>
                        e.SubscriptionEndDate.HasValue
                            ? e.SubscriptionEndDate.Value.Date.ToString(DateTimeConstants.DateFormat)
                            : string.Empty));
            CreateMap<ViewStationReport, StationReportGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.InvoiceDataTime, opt =>
                    opt.MapFrom(e =>
                        e.InvoiceDataTime.HasValue
                            ? e.InvoiceDataTime.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            CreateMap<ViewCarTransaction, CarTransactionGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.TransDate, opt =>
                    opt.MapFrom(e =>
                        e.TransDate.HasValue
                            ? e.TransDate.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            CreateMap<ViewStationSale, StationSaleGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.SumInvoiceDataTime, opt => opt.MapFrom(e => e.SumInvoiceDataTime.ReverseDate()));
            CreateMap<ViewStationStatement, StationStatementGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.InvoiceDataTime, opt => opt.MapFrom(e => e.InvoiceDataTime.ReverseDate()));
            CreateMap<ViewCarTransaction, CarTransactionGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewInvoiceDetail, InvoiceDetailGetResponse>()
                .ForMember(w => w.InvoiceDataTime, opt =>
                    opt.MapFrom(e =>
                        e.InvoiceDataTime.HasValue
                            ? e.InvoiceDataTime.Value.ToString(DateTimeConstants.DateTimeFormat)
                            : ""));
            
            CreateMap<ViewPetrolStationList, PetrolStationListGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            
            CreateMap<ViewAccountBalance, AccountBalanceGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewCarConsumptionRate, CarConsumptionRateGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.DateMin,
                    opt => opt.MapFrom(e =>
                        e.DateMin.HasValue ? e.DateMin.Value.ToString(DateTimeConstants.DateFormat) : string.Empty))
                .ForMember(w => w.DateMax,
                    opt => opt.MapFrom(e =>
                        e.DateMax.HasValue ? e.DateMax.Value.ToString(DateTimeConstants.DateFormat) : string.Empty))
                .ForMember(w => w.CunsumptionRate,
                    opt => opt.MapFrom(e =>
                        e.CunsumptionRate.HasValue
                            ? e.CunsumptionRate.Value.ToString("#.##")
                            : string.Empty));
            CreateMap<ViewCarKmConsumption, CarKmConsumptionGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewCarOdometerMax, CarOdometerMaxGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewCarOdometerMin, CarOdometerMinGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewOdometerBetweenDate, OdometerBetweenDateGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.OdometerRecordDate,
                    opt => opt.MapFrom(e =>
                        e.OdometerRecordDate.HasValue
                            ? e.OdometerRecordDate.Value.ToString(DateTimeConstants.DateFormat)
                            : string.Empty));
            CreateMap<ViewOdometerHistory, OdometerHistoryGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(w => w.OdometerRecordDate,
                    opt => opt.MapFrom(e =>
                        e.OdometerRecordDate.HasValue
                            ? e.OdometerRecordDate.Value.ToString(DateTimeConstants.DateFormat)
                            : string.Empty));
            CreateMap<ViewCustomerStatement, CustomerStatementGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));
            CreateMap<ViewCompanyBranchStatement, CompanyBranchStatementGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => Guid.NewGuid()));


            #endregion
        }
    }
}