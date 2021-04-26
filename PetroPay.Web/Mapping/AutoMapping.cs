using AutoMapper;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Branches.Add;
using PetroPay.Web.Controllers.Branches.Detail;
using PetroPay.Web.Controllers.Branches.Edit;
using PetroPay.Web.Controllers.Branches.Get;
using PetroPay.Web.Controllers.Bundles.Add;
using PetroPay.Web.Controllers.Bundles.Detail;
using PetroPay.Web.Controllers.Bundles.Edit;
using PetroPay.Web.Controllers.Bundles.Get;
using PetroPay.Web.Controllers.Cars.Add;
using PetroPay.Web.Controllers.Cars.Detail;
using PetroPay.Web.Controllers.Cars.Edit;
using PetroPay.Web.Controllers.Cars.Get;
using PetroPay.Web.Controllers.Companies.Add;
using PetroPay.Web.Controllers.Companies.Detail;
using PetroPay.Web.Controllers.Companies.Edit;
using PetroPay.Web.Controllers.Companies.Get;
using PetroPay.Web.Controllers.PetroStations.Add;
using PetroPay.Web.Controllers.PetroStations.Detail;
using PetroPay.Web.Controllers.PetroStations.Edit;
using PetroPay.Web.Controllers.PetroStations.Get;
using PetroPay.Web.Controllers.StationUsers.Add;
using PetroPay.Web.Controllers.StationUsers.Detail;
using PetroPay.Web.Controllers.StationUsers.Edit;
using PetroPay.Web.Controllers.StationUsers.Get;

namespace PetroPay.Web.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
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
            

            /*CreateMap<UserAddRequest, ApiMessages.User>()
                .ForMember(w => w.Password, opt => opt.Ignore());
            
            CreateMap<ApiMessages.User, UserDetailResponse>();*/
        }
    }
}