using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Cars.Get
{
    public class CarGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarGetResponseItem> Items { get; set; }
    }
    public class CarGetResponseItem
    {
        public int Key { get; set; }
        public int CarId { get; set; }
        public string CarIdNumber { get; set; }
        public string CarIdText1E { get; set; }
        public string CarIdText1A { get; set; }
        public string CarIdNumber1E { get; set; }
        public string ConsumptionType { get; set; }
        public decimal? ConsumptionValue { get; set; }
        public string ConsumptionMethod { get; set; }
        public int? CompanyBarnchId { get; set; }
        public decimal? CarBalnce { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        /// <summary>
        /// sedain- truck
        /// </summary>
        public string CarType { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int? CarModelYear { get; set; }
        public string CarTypeOfFuel { get; set; }
        public bool? CarNeedPlatePhoto { get; set; }
        public string CarDriverName { get; set; }
        public string CarDriverPhoneNumber { get; set; }
        public string CarDriverUserName { get; set; }
        public string CarDriverPassword { get; set; }
        public string CarDriverEmail { get; set; }
        public bool? CarDriverActive { get; set; }
        public string CarDriverConfirmationCode { get; set; }
        /*public string CarPlatePhoto { get; set; }*/
        public bool? CarWorkWithApproval { get; set; }
        public bool? CarApprovedOneTime { get; set; }
        public bool? WorkAllDays { get; set; }
        public string CarNfcCode { get; set; }
    }
}
