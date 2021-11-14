﻿using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class StationUser
    {
        public StationUser()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string StationWorkerFname { get; set; }
        public string StationWorkerPhone { get; set; }
        public string StationUserName { get; set; }
        public string StationUserPassword { get; set; }
        public int? StationId { get; set; }
        public int StationWorkerId { get; set; }
        public int? WorkerBonusBalance { get; set; }
        public bool? AccessStationBalance { get; set; }
        public bool? AccessBonusTransfer { get; set; }
        public bool? AccessStationBonusBalance { get; set; }
        public bool? AccessAppReport { get; set; }
        public bool? AccessFuelingApp { get; set; }
        public bool? AccessChangeOilApp { get; set; }
        public bool? AccessCarWasherApp { get; set; }
        public bool? AccessChangeTyreApp { get; set; }
        public bool? AccessTemp1 { get; set; }
        public bool? AccessTemp2 { get; set; }
        public bool? AccessTemp3 { get; set; }

        public virtual PetroStation Station { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
