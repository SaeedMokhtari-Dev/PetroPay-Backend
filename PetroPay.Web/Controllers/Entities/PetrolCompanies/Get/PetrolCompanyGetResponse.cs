using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Get
{
    public class PetrolCompanyGetResponse
    {
        public int TotalCount { get; set; }
        public List<PetrolCompanyGetResponseItem> Items { get; set; }
    }
    public class PetrolCompanyGetResponseItem
    {
        public int Key { get; set; }
        public int PetrolCompanyId { get; set; }
        public string PetrolCompanyName { get; set; }
        public string PetrolCompanyCommercialNumber { get; set; }
        /*public byte[] PetrolCompanyCommercialPhoto { get; set; }*/
        public string PetrolCompanyType { get; set; }
        public string PetrolCompanyAdminUserName { get; set; }
        public string PetrolCompanyAdminUserPassword { get; set; }
        public string PetrolCompanyCountry { get; set; }
        public string PetrolCompanyRegion { get; set; }
        public string PetrolCompanyAddress { get; set; }
        public string PetrolCompanyAdminName { get; set; }
        public string PetrolCompanyAdminPosition { get; set; }
        public string PetrolCompanyAdminPhone { get; set; }
        public string PetrolCompanyAdminEmail { get; set; }
        public decimal? PetrolCompanyBalnce { get; set; }
        
        public string PetrolCompanyVatNumber { get; set; }
        public string PetrolCompanyTaxNumber { get; set; }
    }
}
