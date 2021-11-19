using System;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetroPay.Core.Interfaces;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculator: ITransient
    {
        private readonly PetroPayContext _context;
        private readonly UserContext _userContext;
        public SubscriptionCalculator(PetroPayContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }
        /*public async Task<SubscriptionCalculateResponse> CalculateSubscriptionCost(SubscriptionCalculateRequest request)
        {
            SubscriptionCalculateResponse response = await CalculateSubscriptionCost(request.BundlesId,
                request.SubscriptionCarNumbers,
                request.SubscriptionType, request.SubscriptionStartDate, request.SubscriptionEndDate);
            return response;
        }*/
        public async Task<SubscriptionCalculateResponse> CalculateSubscriptionCost(int bundlesId, int subscriptionCarNumbers, string subscriptionType,
            int numberOf, string couponCode)
        {
            Bundle bundle = await _context.Bundles.SingleOrDefaultAsync(w =>
                w.BundlesId == bundlesId);

            if (bundle == null)
                return null; 

            SubscriptionCalculateResponse response = new SubscriptionCalculateResponse();
            response.BundlesId = bundle.BundlesId;
            
            //DateDiff dateDiff = new DateDiff(subscriptionStartDate, subscriptionEndDate);

            switch (subscriptionType)
            {
                case "Monthly":
                    response.SubscriptionCost = numberOf * (bundle.BundlesFeesMonthly ?? 1) *
                                                subscriptionCarNumbers;
                    break;
                case "Yearly":
                    response.SubscriptionCost = numberOf * (bundle.BundlesFeesYearly ?? 1) *
                                                subscriptionCarNumbers;
                    break;
            }

            response.SubTotal = response.SubscriptionCost;
            if (!string.IsNullOrEmpty(couponCode))
                response = await calculateDiscount(couponCode, subscriptionType, numberOf, response);

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

        private async Task<SubscriptionCalculateResponse> calculateDiscount(string couponCode, string subscriptionType, int numberOf, SubscriptionCalculateResponse response)
        {
            DateTime egyptNowDateTime = DateTime.Now.GetEgyptDateTime();
            var promotion = await _context.PromotionCoupons.FirstOrDefaultAsync(w =>
                w.CouponCode.ToLower().Trim() == couponCode.ToLower().Trim()
                && w.CouponActive.HasValue && w.CouponActive.Value && w.CouponActiveDate.HasValue
                && w.CouponActiveDate.Value <= egyptNowDateTime && w.CouponEndDate.HasValue &&
                w.CouponEndDate.Value >= egyptNowDateTime);
            if (promotion != null && IsValidDiscount(promotion, subscriptionType, numberOf))
            {   
                response.CouponId = promotion.CouponId;
                response.Discount = response.SubscriptionCost * ((promotion.CouponDiscountValue ?? 0) / 100);
                response.SubscriptionCost -= response.Discount;
                response.ValidDiscount = true;
            }
            else
            {
                response.ValidDiscount = false;    
            }

            return response;
        }

        private bool IsValidDiscount(PromotionCoupon promotion, string subscriptionType, int numberOf)
        {
            if (promotion.CouponForAllCustomer ?? false) return true;
            if (promotion.CompanyId.HasValue)
            {
                return _userContext.Id == promotion.CompanyId;
            }
            switch (subscriptionType)
            {
                case "Monthly":
                    if(numberOf >= 3)
                        return promotion.CouponForQuarterly.HasValue && promotion.CouponForQuarterly.Value;
                    return promotion.CouponForMonthly.HasValue && promotion.CouponForMonthly.Value;
                case "Yearly":
                    return promotion.CouponForYearly.HasValue && promotion.CouponForYearly.Value;
            }

            return false;
        }
    }
}