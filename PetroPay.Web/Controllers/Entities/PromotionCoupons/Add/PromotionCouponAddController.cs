using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Add
{
    [Route(Endpoints.ApiPromotionCouponAdd)]
    [ApiExplorerSettings(GroupName = "PromotionCoupon")]
    [Authorize]
    public class PromotionCouponAddController : ApiController<PromotionCouponAddRequest>
    {
        public PromotionCouponAddController(IApiRequestHandler<PromotionCouponAddRequest> handler, IValidator<PromotionCouponAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
