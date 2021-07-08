using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Get
{
    public class PromotionCouponGetHandler : ApiRequestHandler<PromotionCouponGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PromotionCouponGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponGetRequest request)
        {
            var query = _context.PromotionCoupons.OrderBy(w => w.CouponId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PromotionCouponGetResponseItem>>(result);

            PromotionCouponGetResponse response = new PromotionCouponGetResponse();
            response.TotalCount = await _context.PromotionCoupons.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
