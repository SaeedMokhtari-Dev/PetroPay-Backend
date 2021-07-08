using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Delete
{
    public class PromotionCouponDeleteHandler : ApiRequestHandler<PromotionCouponDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PromotionCouponDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponDeleteRequest request)
        {
            PromotionCoupon promotionCoupon = await _context.PromotionCoupons
                .FindAsync(request.PromotionCouponsId);

            if (promotionCoupon == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.PromotionCoupons.Remove(promotionCoupon);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.PromotionCouponMessage.DeletedSuccessfully);
        }
    }
}
