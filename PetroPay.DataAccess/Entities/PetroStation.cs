using System;
using System.Collections.Generic;
using TestScaffold.Models;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class PetroStation
    {
        public PetroStation()
        {
            Invoices = new HashSet<Invoice>();
            StationUsers = new HashSet<StationUser>();
        }

        public string StationName { get; set; }
        public string StationAddress { get; set; }
        public string StationLucationName { get; set; }
        public string StationOwnerName { get; set; }
        public string StationPhone { get; set; }
        public string StationBanckAccount { get; set; }
        public double? StationLatitude { get; set; }
        public double? StationLongitude { get; set; }
        public string StationUserName { get; set; }
        public string StationPassword { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public int? AccountId { get; set; }
        public string StationNameAr { get; set; }
        public bool? StationDiesel { get; set; }
        public decimal? StationBalance { get; set; }
        public string StationEmail { get; set; }
        public bool? StationServiceActive { get; set; }
        public bool? StationServiceDeposit { get; set; }
        public bool? StationChangeOilService { get; set; }
        public bool? StationCarWashingService { get; set; }
        public bool? StationChangeTireService { get; set; }
        public int? StationBonusBalance { get; set; }
        public int StationId { get; set; }
        public int? PetrolCompanyId { get; set; }

        public virtual AccountMaster Account { get; set; }
        public virtual PetrolCompany PetrolCompany { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<StationUser> StationUsers { get; set; }
    }
}
