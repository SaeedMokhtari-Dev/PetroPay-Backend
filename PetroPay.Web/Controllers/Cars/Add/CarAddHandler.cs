using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Cars.Add
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