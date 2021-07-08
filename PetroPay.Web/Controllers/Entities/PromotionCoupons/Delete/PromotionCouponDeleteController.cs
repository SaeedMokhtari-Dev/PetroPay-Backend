using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Delete
{
    [Route(Endpoints.ApiPromotionCouponDelete)]
    [ApiExplorerSettings(GroupName = "PromotionCoupon")]
    [Authorize]
    public class PromotionCouponDeleteController : ApiController<PromotionCouponDeleteRequest>
    {
        public PromotionCouponDeleteController(IApiRequestHandler<PromotionCouponDeleteRequest> handler, IValidator<PromotionCouponDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
