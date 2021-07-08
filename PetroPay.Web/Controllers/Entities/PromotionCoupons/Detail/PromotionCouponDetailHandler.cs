using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Detail
{
    public class PromotionCouponDetailHandler : ApiRequestHandler<PromotionCouponDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PromotionCouponDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponDetailRequest request)
        {
            PromotionCoupon promotionCoupon = await _context.PromotionCoupons
                .FindAsync(request.PromotionCouponsId);

            if (promotionCoupon == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            PromotionCouponDetailResponse response = _mapper.Map<PromotionCouponDetailResponse>(promotionCoupon);
            
            return ActionResult.Ok(response);
        }
    }
}
