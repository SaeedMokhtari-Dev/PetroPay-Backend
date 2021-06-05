using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Cars.Add
{
    public class CarAddHandler : ApiRequestHandler<CarAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public CarAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarAddRequest request)
        {
            var isUsernameDuplicate =
                _context.Cars.Any(w => w.CarDriverUserName.Trim().ToUpper() == request.CarDriverUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            CompanyBranch branch =
                await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == request.CompanyBarnchId);
            
            if(branch == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            var branchCarCount = await _context.Cars.CountAsync(w =>
                w.CompanyBarnchId.HasValue && w.CompanyBarnchId == branch.CompanyBranchId); 
            if(branchCarCount >= (branch.CompanyBranchNumberOfcar ?? 0))
                return ActionResult.Error(ApiMessages.CarMessage.AddMoreThanMaxNotAllowed);

            /*var sumCarSubscription = await _context.Subscriptions
                .Where(w => branch.CompanyId.HasValue && w.CompanyId == branch.CompanyId.Value && w.SubscriptionActive == true)
                .SumAsync(w => w.SubscriptionCarNumbers);

            var allCompanyCars = await _context.Cars.Where(w =>
                branch.CompanyId.HasValue && w.CompanyBarnch.CompanyId == branch.CompanyId.Value).CountAsync();
            
            if((!sumCarSubscription.HasValue) || sumCarSubscription.Value <= allCompanyCars)
                return ActionResult.Error(ApiMessages.CarMessage.AddMoreThanSubscriptionsNotAllowed);*/
            
            Car car = await AddCar(request);
            
            return ActionResult.Ok(ApiMessages.CarMessage.AddedSuccessfully);
        }
        
        private async Task<Car> AddCar(CarAddRequest request)
        {
            Car car = await _context.ExecuteTransactionAsync(async () =>
            {
                Car newCar = _mapper.Map<Car>(request);

                if (request.CarNeedPlatePhoto.HasValue && request.CarNeedPlatePhoto.Value)
                {
                    if(!string.IsNullOrEmpty(request.CarPlatePhoto))
                        newCar.CarPlatePhoto = request.CarPlatePhoto;    
                }
                

                AccountMaster accountMaster = new AccountMaster();
                accountMaster.AccountName = request.CarIdNumber;
                accountMaster.AccountTaype = "Car";

                newCar.Account = accountMaster;
                
                newCar = (await _context.Cars.AddAsync(newCar)).Entity;
                await _context.SaveChangesAsync();

                return newCar;
            });
            return car;
        }
    }
}