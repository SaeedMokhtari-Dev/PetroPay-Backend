using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Companies.Get
{
    public class CompanyGetResponse
    {
        public int TotalCount { get; set; }
        public List<CompanyGetResponseItem> Items { get; set; }
    }
    public class CompanyGetResponseItem
    {
        public int Key { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCommercialNumber { get; set; }
        /*public byte[] CompanyCommercialPhoto { get; set; }*/
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
        
        public string CompanyVatNumber { get; set; }
        public string CompanyTaxNumber { get; set; }
    }
}
