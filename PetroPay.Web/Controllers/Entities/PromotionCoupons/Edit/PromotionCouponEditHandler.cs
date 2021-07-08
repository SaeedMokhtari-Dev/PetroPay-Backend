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

            await EditAuditingPromotionCouponPromotionCouponPromotionCoupon(editPromotionCoupon, request);
            return ActionResult.Ok(ApiMessages.PromotionCouponMessage.EditedSuccessfully);
        }

        private async Task EditAuditingPromotionCouponPromotionCouponPromotionCoupon(PromotionCoupon editPromotionCoupon, PromotionCouponEditRequest request)
        {
            _mapper.Map(request, editPromotionCoupon);
            await _context.SaveChangesAsync();
        }
    }
}