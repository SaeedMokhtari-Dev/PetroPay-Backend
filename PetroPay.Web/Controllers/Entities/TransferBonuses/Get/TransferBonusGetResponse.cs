using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Get
{
    public class TransferBonusGetResponse
    {
        public int TotalCount { get; set; }
        public List<TransferBonusGetResponseItem> Items { get; set; }
    }
    public class TransferBonusGetResponseItem
    {
        public int Key { get; set; }
        public int TransId { get; set; }
        public string TransDate { get; set; }
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
        public string TransReference { get; set; }
    }
}
