using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Detail
{
    public class SubscriptionDetailHandler : ApiRequestHandler<SubscriptionDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionDetailRequest request)
        {
            Subscription subscription = await _context.Subscriptions.Include(w => w.CarSubscriptions)
                .FirstOrDefaultAsync(w => w.SubscriptionId == request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            SubscriptionDetailResponse response = _mapper.Map<SubscriptionDetailResponse>(subscription);
            /*DateDiff dateDiff = new DateDiff(subscription.SubscriptionStartDate ?? DateTime.Now, subscription.SubscriptionEndDate ?? DateTime.Now);
            switch (subscription.SubscriptionType)
            {
                case "Monthly":
                    response.NumberOfDateDiff = dateDiff.Months;
                    break;
                case "Yearly":
                    response.NumberOfDateDiff = dateDiff.Years;
                    break;
            }*/
            /*var dateDiff = (subscription.SubscriptionEndDate ?? DateTime.Now) -
                           (subscription.SubscriptionStartDate ?? DateTime.Now);
            switch (subscription.SubscriptionType)
            {
                case "Monthly":
                    response.NumberOfDateDiff = dateDiff.;
                    break;
                case "Yearly":
                    response.NumberOfDateDiff = dateDiff.Years;
                    break;
            }*/
                        

            /*var petropayAccount = await _context.PetropayAccounts.FirstOrDefaultAsync(
                 w => w.AccName == response.SubscriptionPaymentMethod);
            if (petropayAccount != null)
                response.PetropayAccountId = petropayAccount.AccId;*/
                

            response.SubscriptionCars = subscription.CarSubscriptions.Select(w => new SubscriptionCar()
            {
                Key = w.CarId,
                Disabled = w.Invoiced ?? false
            }).ToList();
            
            return ActionResult.Ok(response);
        }
    }
}
