using AutoMapper;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Bundles.Add;
using PetroPay.Web.Controllers.Bundles.Detail;
using PetroPay.Web.Controllers.Bundles.Edit;
using PetroPay.Web.Controllers.Bundles.Get;
using PetroPay.Web.Controllers.Companies.Add;
using PetroPay.Web.Controllers.Companies.Detail;
using PetroPay.Web.Controllers.Companies.Edit;
using PetroPay.Web.Controllers.Companies.Get;

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