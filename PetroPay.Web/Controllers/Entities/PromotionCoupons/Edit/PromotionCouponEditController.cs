using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Edit
{
    [Route(Endpoints.ApiPromotionCouponEdit)]
    [ApiExplorerSettings(GroupName = "PromotionCoupon")]
    [Authorize]
    public class PromotionCouponEditController : ApiController<PromotionCouponEditRequest>
    {
        public PromotionCouponEditController(IApiRequestHandler<PromotionCouponEditRequest> handler, IValidator<PromotionCouponEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
