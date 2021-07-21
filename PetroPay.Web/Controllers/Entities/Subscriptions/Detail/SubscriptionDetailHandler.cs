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
                .ThenInclude(w => w.Car).ThenInclude(w => w.CompanyBarnch)
                .Include(w => w.Company)
                .FirstOrDefaultAsync(w => w.SubscriptionId == request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            SubscriptionDetailResponse response = _mapper.Map<SubscriptionDetailResponse>(subscription);
           
            response.SubscriptionCars = subscription.CarSubscriptions.Select(w => new SubscriptionCar()
            {
                Key = w.CarId,
                CarIdNumber = w.Car.CarIdNumber,
                BranchId =  w.Car.CompanyBarnchId ?? 0,
                BranchName = w.Car.CompanyBarnchId.HasValue ? w.Car.CompanyBarnch.CompanyBranchName : string.Empty,
                Disabled = w.Invoiced ?? false
            }).ToList();
            
            return ActionResult.Ok(response);
        }
    }
}
