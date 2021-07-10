using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Add
{
    public class PromotionCouponAddHandler : ApiRequestHandler<PromotionCouponAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        
        public PromotionCouponAddHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            this._context = context;
            this._mapper = mapper;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(PromotionCouponAddRequest request)
        {
            Tuple<bool, string> result = await AddPromotionCoupon(request);
            if(result.Item1)
                return ActionResult.Ok(ApiMessages.PromotionCouponMessage.AddedSuccessfully);
            return ActionResult.Error(result.Item2);
        }
        
        private async Task<Tuple<bool, string>> AddPromotionCoupon(PromotionCouponAddRequest request)
        {
            Tuple<bool, string> result = await _context.ExecuteTransactionAsync(async () =>
            {
                //int maxId = await _context.PromotionCoupons.MaxAsync(w => w.CouponId);
                PromotionCoupon newPromotionCoupon = _mapper.Map<PromotionCoupon>(request);
                //newPromotionCoupon.CouponId = ++maxId;
                if (newPromotionCoupon.CouponEndDate <= newPromotionCoupon.CouponActiveDate)
                    return new Tuple<bool, string>(false, ApiMessages.PromotionCouponMessage.StartDateShouldBeLessThanEndDate);

                var user = await _userService.GetCurrentUserInfo();
                if (user.Item1)
                {
                    newPromotionCoupon.UserId = user.Item2.Id;
                    newPromotionCoupon.UserName = user.Item2.Name;
                }

                newPromotionCoupon = (await _context.PromotionCoupons.AddAsync(newPromotionCoupon)).Entity;
                await _context.SaveChangesAsync();

                return new Tuple<bool, string>(true, string.Empty);
            });
            return result;
        }
    }
}