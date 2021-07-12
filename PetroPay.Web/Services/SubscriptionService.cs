using System;
using System.Linq;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.Core.Interfaces;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Controllers.Auth.GetUserInfo;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Services
{
    public class SubscriptionService: ITransient
    {
        private readonly PetroPayContext _context;
        
        public SubscriptionService(PetroPayContext context)
        {
            _context = context;
        }

        public async Task<double> GetSubscriptionInvoiceNumber()
        {
            var maxInvoiceNumber = await _context.Subscriptions.Where(w => w.SubscriptionInvoiceNumber.HasValue)
                .MaxAsync(w => w.SubscriptionInvoiceNumber);

            var year = DateTime.Now.Year;

            if (maxInvoiceNumber.HasValue && maxInvoiceNumber.Value > 0 && maxInvoiceNumber.Value.ToString().StartsWith(year.ToString()))
            {
                return maxInvoiceNumber.Value + 1;
            }

            return Convert.ToDouble($"{year}{"1".PadLeft(5, '0')}");
        }
    }
}