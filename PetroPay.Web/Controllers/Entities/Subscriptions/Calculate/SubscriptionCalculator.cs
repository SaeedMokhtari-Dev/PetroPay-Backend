using System;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
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
            DateTime subscriptionStartDate, DateTime subscriptionEndDate)
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

            return response;
        }
    }
}