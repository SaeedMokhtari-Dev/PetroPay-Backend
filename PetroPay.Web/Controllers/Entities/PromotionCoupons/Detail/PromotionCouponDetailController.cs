using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Detail
{
    [Route(Endpoints.ApiPromotionCouponDetail)]
    [ApiExplorerSettings(GroupName = "PromotionCoupon")]
    [Authorize]
    public class PromotionCouponDetailController : ApiController<PromotionCouponDetailRequest>
    {
        public PromotionCouponDetailController(IApiRequestHandler<PromotionCouponDetailRequest> handler, IValidator<PromotionCouponDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
