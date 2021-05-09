using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.StationStatements.Get
{
    public class StationStatementGetResponse
    {
        public int TotalCount { get; set; }
        public List<StationStatementGetResponseItem> Items { get; set; }
    }
    public class StationStatementGetResponseItem
    {
        public Guid Key { get; set; }
        public string InvoiceDataTime { get; set; }
        public int? AccountId { get; set; }
        public string StationName { get; set; }
        public string TransDocument { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string AccountName { get; set; }
        public int StationId { get; set; }
    }
}
