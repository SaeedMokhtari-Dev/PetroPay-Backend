using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
                .SingleOrDefaultAsync(w => w.SubscriptionId == request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            SubscriptionDetailResponse response = _mapper.Map<SubscriptionDetailResponse>(subscription);

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
