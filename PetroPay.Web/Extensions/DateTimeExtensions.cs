using System;

namespace PetroPay.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetEgyptDateTime(this DateTime dateTime)
        {
            DateTimeOffset localDate = DateTimeOffset.Now; //new DateTimeOffset(2017, 11, 14, 12, 0, 0, origTimeZone.BaseUtcOffset);

            TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            DateTimeOffset test = TimeZoneInfo.ConvertTime(localDate, newTimeZone);
            return test.DateTime;
        }
    }
}