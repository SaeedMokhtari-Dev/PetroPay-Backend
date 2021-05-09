using System;
using System.Linq;

namespace PetroPay.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ReverseDate(this string s)
        {
            var dateSplit = s.Split("/");
            Array.Reverse(dateSplit);
            return String.Join("/", dateSplit);
        }
    }
}