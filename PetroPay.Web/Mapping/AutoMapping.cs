using System;
using AutoMapper;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Entities;
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
using PetroPay.Web.Controllers.Entities.PetroStations.Add;
using PetroPay.Web.Controllers.Entities.PetroStations.Detail;
using PetroPay.Web.Controllers.Entities.PetroStations.Edit;
using PetroPay.Web.Controllers.Entities.PetroStations.Get;
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
using PetroPay.Web.Controllers.Reports.InvoiceDetails.Get;
using PetroPay.Web.Controllers.Reports.InvoiceSummary.Get;

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
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore());
            CreateMap<CompanyEditRequest, Company>()
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore());
            CreateMap<CompanyAddRequest, Company>()
                .ForMember(w => w.CompanyCommercialPhoto, opt => opt.Ignore());
            
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
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.CarId));
            CreateMap<Car, CarDetailResponse>();
            CreateMap<CarEditRequest, Car>()
                .ForMember(w => w.CarId, opt => opt.Ignore())
                .ForMember(w => w.CompanyBarnchId, opt => opt.Ignore());
            CreateMap<CarAddRequest, Car>();
            
            #endregion
            #region Subscription

            CreateMap<Subscription, SubscriptionGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.SubscriptionId))
                .ForMember(w => w.CompanyName, opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")));
            CreateMap<Subscription, SubscriptionDetailResponse>()
                .ForMember(w => w.CompanyName, opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")));
            CreateMap<SubscriptionEditRequest, Subscription>()
                .ForMember(w => w.SubscriptionId, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore());
            CreateMap<SubscriptionAddRequest, Subscription>()
                .ForMember(w => w.SubscriptionDate, opt => opt.MapFrom(src => DateTime.Now));
            
            #endregion
            #region RechargeBalance

            CreateMap<RechargeBalance, RechargeBalanceGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.RechargeId))
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")));
            CreateMap<RechargeBalance, RechargeBalanceDetailResponse>()
                .ForMember(w => w.CompanyName,
                    opt => opt.MapFrom(e => (e.Company != null ? e.Company.CompanyName : "")));
            CreateMap<RechargeBalanceEditRequest, RechargeBalance>()
                .ForMember(w => w.RechargeId, opt => opt.Ignore())
                .ForMember(w => w.CompanyId, opt => opt.Ignore());
            CreateMap<RechargeBalanceAddRequest, RechargeBalance>()
                .ForMember(w => w.RechageDate, opt => opt.MapFrom(src => DateTime.Now));
            
            #endregion
            #region PetroStation
            
            CreateMap<PetroStation, PetroStationGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.StationId));
            CreateMap<PetroStation, PetroStationDetailResponse>();
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

            #endregion

            #region Reports

            #region InvoiceSummary

            CreateMap<ViewInvoicesSummary, InvoiceSummaryGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.InvoiceId));
            CreateMap<ViewInvoiceDetail, InvoiceDetailGetResponse>();
                        
            #endregion

            #endregion
        }
    }
}