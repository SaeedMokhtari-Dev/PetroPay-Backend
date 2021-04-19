using AutoMapper;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Entities;
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
            

            /*CreateMap<UserAddRequest, ApiMessages.User>()
                .ForMember(w => w.Password, opt => opt.Ignore());
            
            CreateMap<ApiMessages.User, UserDetailResponse>();*/
        }
    }
}