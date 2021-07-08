#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class AppSetting
    {
        public string CompanyNameEn { get; set; }
        public string CompanyNameAr { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyCommercialRecordNumber { get; set; }
        public string CompanyVatTaxNumber { get; set; }
        public decimal? CompanyVatRate { get; set; }
        public string ComapnyTaxRecordNumber { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyStampImage { get; set; }
        public decimal? ComapnyTaxRate { get; set; }
    }
}
