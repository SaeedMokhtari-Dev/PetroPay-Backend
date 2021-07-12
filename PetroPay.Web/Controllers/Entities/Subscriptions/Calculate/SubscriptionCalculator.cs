using System;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetroPay.Core.Interfaces;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculator: ITransient
    {
        private readonly PetroPayContext _context;
        public SubscriptionCalculator(PetroPayContext context)
        {
            _context = context;
        }
        /*public async Task<SubscriptionCalculateResponse> CalculateSubscriptionCost(SubscriptionCalculateRequest request)
        {
            SubscriptionCalculateResponse response = await CalculateSubscriptionCost(request.BundlesId,
                request.SubscriptionCarNumbers,
                request.SubscriptionType, request.SubscriptionStartDate, request.SubscriptionEndDate);
            return response;
        }*/
        public async Task<SubscriptionCalculateResponse> CalculateSubscriptionCost(int bundlesId, int subscriptionCarNumbers, string subscriptionType,
            DateTime subscriptionStartDate, DateTime subscriptionEndDate, string couponCode)
        {
            Bundle bundle = await _context.Bundles.SingleOrDefaultAsync(w =>
                w.BundlesId == bundlesId);

            if (bundle == null)
                return null; 

            SubscriptionCalculateResponse response = new SubscriptionCalculateResponse();
            response.BundlesId = bundle.BundlesId;
            
            DateDiff dateDiff = new DateDiff(subscriptionStartDate, subscriptionEndDate);

            switch (subscriptionType)
            {
                case "Monthly":
                    response.SubscriptionCost = dateDiff.Months * (bundle.BundlesFeesMonthly ?? 1) *
                                                subscriptionCarNumbers;
                    break;
                case "Yearly":
                    response.SubscriptionCost = dateDiff.Years * (bundle.BundlesFeesYearly ?? 1) *
                                                subscriptionCarNumbers;
                    break;
            }

            response.SubTotal = response.SubscriptionCost;
            if (!string.IsNullOrEmpty(couponCode))
                response = await calculateDiscount(couponCode, response);

            response = await appendTaxAndVat(response);
            return response;
        }

        private async Task<SubscriptionCalculateResponse> appendTaxAndVat(SubscriptionCalculateResponse response)
        {
            var appSetting = await _context.AppSettings.FirstOrDefaultAsync();
            if (appSetting != null)
            {
                response.TaxRate = appSetting.ComapnyTaxRate ?? 0;
                response.VatRate = appSetting.CompanyVatRate ?? 0;

                response.Tax = (response.SubscriptionCost) * (response.TaxRate / 100);
                response.Vat = (response.SubscriptionCost) * (response.VatRate / 100);

                response.SubscriptionCost += response.Tax + response.Vat;
            }

            return response;
        }

        private async Task<SubscriptionCalculateResponse> calculateDiscount(string couponCode, SubscriptionCalculateResponse response)
        {
            var promotion = await _context.PromotionCoupons.FirstOrDefaultAsync(w =>
                w.CouponCode.ToLower() == couponCode.ToLower()
                && w.CouponActive.HasValue && w.CouponActive.Value && w.CouponActiveDate.HasValue
                && w.CouponActiveDate.Value <= DateTime.Now && w.CouponEndDate.HasValue &&
                w.CouponEndDate.Value >= DateTime.Now);
            if (promotion != null)
            {
                response.CouponId = promotion.CouponId;
                response.Discount = response.SubscriptionCost * ((promotion.CouponDiscountValue ?? 0) / 100);
                response.SubscriptionCost -= response.Discount;
            }

            return response;
        }
    }
}