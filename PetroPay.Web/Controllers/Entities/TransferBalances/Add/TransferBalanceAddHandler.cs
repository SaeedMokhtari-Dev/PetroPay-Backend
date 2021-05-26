using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.Add
{
    public class TransferBalanceAddHandler : ApiRequestHandler<TransferBalanceAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public TransferBalanceAddHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(TransferBalanceAddRequest request)
        {
            if(_userContext.Role != RoleType.Customer)
                return ActionResult.Error(ApiMessages.Forbidden);

            if (!request.CompanyId.HasValue)
                request.CompanyId = _userContext.Id;

            Tuple<bool, string> result;
            switch (request.TransferBalanceType)
            {
                case TransferBalanceType.CompanyToBranch:
                    if(!request.CompanyId.HasValue || !request.BranchId.HasValue)
                        return ActionResult.Error(ApiMessages.InvalidRequest);
                    
                    result = await TransferCompanyToBranch(request.CompanyId.Value, request.BranchId.Value, request.Amount);
                    
                    break;
                case TransferBalanceType.BranchToCompany:
                    if(!request.CompanyId.HasValue || !request.BranchId.HasValue)
                        return ActionResult.Error(ApiMessages.InvalidRequest);
                    
                    result = await TransferBranchToCompany(request.CompanyId.Value, request.BranchId.Value, request.Amount);
                    break;
                case TransferBalanceType.CarToCar:
                    if(!request.CarId.HasValue || !request.DestinationCarId.HasValue)
                        return ActionResult.Error(ApiMessages.InvalidRequest);
                    
                    result = await TransferCarToCar(request.CarId.Value, request.DestinationCarId.Value, request.Amount);
                    break;
                case TransferBalanceType.CarToBranch:
                    if(!request.CarId.HasValue || !request.BranchId.HasValue)
                        return ActionResult.Error(ApiMessages.InvalidRequest);
                    
                    result = await TransferCarToBranch(request.CarId.Value, request.BranchId.Value, request.Amount);
                    break;
                case TransferBalanceType.BranchToCar:
                    if(!request.CarId.HasValue || !request.BranchId.HasValue)
                        return ActionResult.Error(ApiMessages.InvalidRequest);
                    
                    result = await TransferBranchToCar(request.CarId.Value, request.BranchId.Value, request.Amount);
                    break;
                
                default:
                    result = new Tuple<bool, string>(false, ApiMessages.InvalidRequest);
                    break;
            }
            
            if(!result.Item1)
                return ActionResult.Error(result.Item2);
            
            return ActionResult.Ok(result.Item2);
        }

        private async Task<Tuple<bool, string>> TransferCompanyToBranch(int companyId, int branchId, decimal amount)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == companyId);
            if (company == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var branch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == branchId);
            if (branch == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(company.CompanyBalnce < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                company.CompanyBalnce -= amount;
                TransAccount deductFromCompany = new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = -1 * (amount),
                    TransDate = DateTime.Now,
                    TransDocument = "Recharge Branch Balance",
                    TransReference = branch.AccountId.ToString()
                };
                deductFromCompany = (await _context.TransAccounts.AddAsync(deductFromCompany)).Entity;

                branch.CompanyBranchBalnce += amount;
                TransAccount addToBranchAccount = new TransAccount()
                {
                    AccountId = branch.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Recharge Branch Balance",
                    TransReference = company.AccountId.ToString()
                };
                addToBranchAccount = (await _context.TransAccounts.AddAsync(addToBranchAccount)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }

        private async Task<Tuple<bool, string>> TransferBranchToCompany(int companyId, int branchId, decimal amount)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == companyId);
            if (company == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var branch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == branchId);
            if (branch == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(branch.CompanyBranchBalnce < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                branch.CompanyBranchBalnce -= amount;
                TransAccount deductFromBranchAccount = new TransAccount()
                {
                    AccountId = branch.AccountId,
                    TransAmount = -1 * amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Refund Branch Balance To Company",
                    TransReference = company.AccountId.ToString()
                };
                deductFromBranchAccount = (await _context.TransAccounts.AddAsync(deductFromBranchAccount)).Entity;
                
                company.CompanyBalnce += amount;
                TransAccount addToCompany = new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Refund Branch Balance To Company",
                    TransReference = branch.AccountId.ToString()
                };
                addToCompany = (await _context.TransAccounts.AddAsync(addToCompany)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }

        private async Task<Tuple<bool, string>> TransferCarToCar(int carId, int destinationCarId, decimal amount)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(w => w.CarId == carId);
            if (car == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var destinationCar = await _context.Cars.SingleOrDefaultAsync(w => w.CarId == destinationCarId);
            if (destinationCar == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(car.CarBalnce < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                car.CarBalnce -= amount;
                TransAccount deductFromCarAccount = new TransAccount()
                {
                    AccountId = car.AccountId,
                    TransAmount = -1 * amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Transfer Balance Car To Car",
                    TransReference = destinationCar.AccountId.ToString()
                };
                deductFromCarAccount = (await _context.TransAccounts.AddAsync(deductFromCarAccount)).Entity;
                
                destinationCar.CarBalnce += amount;
                TransAccount addToDestinationCar = new TransAccount()
                {
                    AccountId = destinationCar.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Transfer Balance Car To Car",
                    TransReference = car.AccountId.ToString()
                };
                addToDestinationCar = (await _context.TransAccounts.AddAsync(addToDestinationCar)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }
        private async Task<Tuple<bool, string>> TransferBranchToCar(int carId, int branchId, decimal amount)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(w => w.CarId == carId);
            if (car == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var branch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == branchId);
            if (branch == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(branch.CompanyBranchBalnce < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                branch.CompanyBranchBalnce -= amount;
                TransAccount deductFromBranchAccount = new TransAccount()
                {
                    AccountId = branch.AccountId,
                    TransAmount = -1 * amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Recharge Car Balance",
                    TransReference = car.AccountId.ToString()
                };
                deductFromBranchAccount = (await _context.TransAccounts.AddAsync(deductFromBranchAccount)).Entity;
                
                car.CarBalnce += amount;
                TransAccount addToCar = new TransAccount()
                {
                    AccountId = car.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Recharge Car Balance",
                    TransReference = branch.AccountId.ToString()
                };
                addToCar = (await _context.TransAccounts.AddAsync(addToCar)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }
        private async Task<Tuple<bool, string>> TransferCarToBranch(int carId, int branchId, decimal amount)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(w => w.CarId == carId);
            if (car == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var branch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == branchId);
            if (branch == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(car.CarBalnce < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                car.CarBalnce -= amount;
                TransAccount deductFromCar = new TransAccount()
                {
                    AccountId = car.AccountId,
                    TransAmount = -1 * amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Refund Balance Car To Branch",
                    TransReference = branch.AccountId.ToString()
                };
                deductFromCar = (await _context.TransAccounts.AddAsync(deductFromCar)).Entity;
                
                branch.CompanyBranchBalnce += amount;
                TransAccount addToBranchAccount = new TransAccount()
                {
                    AccountId = branch.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Refund Balance Car To Branch",
                    TransReference = car.AccountId.ToString()
                };
                addToBranchAccount = (await _context.TransAccounts.AddAsync(addToBranchAccount)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }
    }
}
