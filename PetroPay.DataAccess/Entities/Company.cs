using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Company
    {
        public Company()
        {
            CompanyBranches = new HashSet<CompanyBranch>();
            RechargeBalances = new HashSet<RechargeBalance>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCommercialNumber { get; set; }
        public byte[] CompanyCommercialPhoto { get; set; }
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
        public byte[] SsmaTimeStamp { get; set; }
        public int? AccountId { get; set; }
        public string CompanyVatNumber { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string CompanyVatPhoto { get; set; }
        public string CompanyTaxPhoto { get; set; }

        public virtual AccountMaster Account { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<RechargeBalance> RechargeBalances { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
