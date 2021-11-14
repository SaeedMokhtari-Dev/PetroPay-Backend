using System;
using System.Collections.Generic;
using PetroPay.DataAccess.Entities;

#nullable disable

namespace TestScaffold.Models
{
    public partial class PetrolCompany
    {
        public PetrolCompany()
        {
            PetroStations = new HashSet<PetroStation>();
        }

        public int PetrolCompanyId { get; set; }
        public string PetrolCompanyName { get; set; }
        public string PetrolCompanyCommercialNumber { get; set; }
        public byte[] PetrolCompanyCommercialPhoto { get; set; }
        public string PetrolCompanyCountry { get; set; }
        public string PetrolCompanyRegion { get; set; }
        public string PetrolCompanyAddress { get; set; }
        public string PetrolCompanyAdminName { get; set; }
        public string PetrolCompanyAdminPosition { get; set; }
        public string PetrolCompanyAdminPhone { get; set; }
        public string PetrolCompanyAdminEmail { get; set; }
        public string PetrolCompanyAdminUserName { get; set; }
        public string PetrolCompanyAdminUserPassword { get; set; }
        public decimal? PetrolCompanyBalnce { get; set; }
        public string PetrolCompanyVatNumber { get; set; }
        public string PetrolCompanyTaxNumber { get; set; }
        public string PetrolCompanyVatPhoto { get; set; }
        public string PetrolCompanyTaxPhoto { get; set; }
        public int? AccountId { get; set; }

        public virtual ICollection<PetroStation> PetroStations { get; set; }
    }
}
