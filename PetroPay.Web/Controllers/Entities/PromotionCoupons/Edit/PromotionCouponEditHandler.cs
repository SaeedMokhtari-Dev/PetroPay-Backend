using System;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Edit
{
    public class PromotionCouponEditHandler : ApiRequestHandler<PromotionCouponEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PromotionCouponEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponEditRequest request)
        {
            PromotionCoupon editPromotionCoupon = await _context.PromotionCoupons
                .FindAsync(request.CouponId);

            if (editPromotionCoupon == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            Tuple<bool, string> result = await EditAuditingPromotionCouponPromotionCouponPromotionCoupon(editPromotionCoupon, request);
            
            if(result.Item1)
                return ActionResult.Ok(ApiMessages.PromotionCouponMessage.EditedSuccessfully);
            return ActionResult.Error(result.Item2);
        }

        private async Task<Tuple<bool, string>> EditAuditingPromotionCouponPromotionCouponPromotionCoupon(PromotionCoupon editPromotionCoupon, PromotionCouponEditRequest request)
        {
            _mapper.Map(request, editPromotionCoupon);
            if (editPromotionCoupon.CouponEndDate <= editPromotionCoupon.CouponActiveDate)
                return new Tuple<bool, string>(false, ApiMessages.PromotionCouponMessage.StartDateShouldBeLessThanEndDate);
            await _context.SaveChangesAsync();
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}