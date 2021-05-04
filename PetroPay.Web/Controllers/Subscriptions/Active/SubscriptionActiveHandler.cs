using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Subscriptions.Active
{
    public class SubscriptionActiveHandler : ApiRequestHandler<SubscriptionActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionActiveHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionActiveRequest request)
        {
            Subscription subscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (subscription.SubscriptionActive.HasValue && subscription.SubscriptionActive.Value)
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            Company company = await _context.Companies.FindAsync(subscription.CompanyId);
            
            if(company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (subscription.SubscriptionPaymentMethod == "CompanyBalance")
            {
                if((!company.CompanyBalnce.HasValue) || company.CompanyBalnce.Value < subscription.SubscriptionCost)
                    return ActionResult.Error(ApiMessages.NotEnoughBalance);

                company.CompanyBalnce -= subscription.SubscriptionCost ?? 0;
            }

            subscription.SubscriptionActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.ActivatedSuccessfully);
        }
    }
}
