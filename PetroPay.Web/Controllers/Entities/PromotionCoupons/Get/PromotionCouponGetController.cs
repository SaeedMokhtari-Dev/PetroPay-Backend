using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Get
{
    [Route(Endpoints.ApiPromotionCouponGet)]
    [ApiExplorerSettings(GroupName = "PromotionCoupon")]
    [Authorize]
    public class PromotionCouponGetController : ApiController<PromotionCouponGetRequest>
    {
        public PromotionCouponGetController(IApiRequestHandler<PromotionCouponGetRequest> handler, IValidator<PromotionCouponGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
