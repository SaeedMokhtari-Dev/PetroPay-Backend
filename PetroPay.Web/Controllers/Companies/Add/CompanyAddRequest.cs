using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Companies.Add
{
    public class CompanyAddRequest
    {
        public string CompanyName { get; set; }
        public string CompanyCommercialNumber { get; set; }
        public string CompanyCommercialPhoto { get; set; }
        public string CompanyType { get; set; }
        public string CompanyAdminUserName { get; set; }
        public string CompanyAdminUserPassword { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyRegion { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyAdminName { get; set; }
        public string CompanyAdminPosition { get; set; }
        public string CompanyAdminPhone { get; set; }
        public string CompanyAdminEmail { get; set; }
        public decimal? CompanyBalnce { get; set; }
    }
}
