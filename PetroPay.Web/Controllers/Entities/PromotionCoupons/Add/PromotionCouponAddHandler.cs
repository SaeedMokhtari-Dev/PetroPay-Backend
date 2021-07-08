using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Add
{
    public class PromotionCouponAddHandler : ApiRequestHandler<PromotionCouponAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PromotionCouponAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponAddRequest request)
        {
            PromotionCoupon promotionCoupon = await AddPromotionCoupon(request);
            
            return ActionResult.Ok(ApiMessages.PromotionCouponMessage.AddedSuccessfully);
        }
        
        private async Task<PromotionCoupon> AddPromotionCoupon(PromotionCouponAddRequest request)
        {
            PromotionCoupon promotionCoupon = await _context.ExecuteTransactionAsync(async () =>
            {
                //int maxId = await _context.PromotionCoupons.MaxAsync(w => w.CouponId);
                PromotionCoupon newPromotionCoupon = _mapper.Map<PromotionCoupon>(request);
                //newPromotionCoupon.CouponId = ++maxId;
                newPromotionCoupon = (await _context.PromotionCoupons.AddAsync(newPromotionCoupon)).Entity;
                await _context.SaveChangesAsync();

                return newPromotionCoupon;
            });
            return promotionCoupon;
        }
    }
}