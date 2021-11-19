using System;
using System.Threading.Tasks;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.Core.Interfaces;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Controllers.Auth.GetUserInfo;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Services
{
    public class UserService: ITransient
    {
        private readonly UserContext _userContext;
        private readonly PetroPayContext _context;
        
        public UserService(UserContext userContext, PetroPayContext context)
        {
            _userContext = userContext;
            _context = context;
        }

        public async Task<Tuple<bool, GetUserInfoResponse, string>> GetCurrentUserInfo()
        {
            switch (_userContext.Role)
            {
                case  RoleType.Customer:
                    var customer = await _context.Companies.FindAsync(_userContext.Id);
                    if (customer != null)
                        return new Tuple<bool, GetUserInfoResponse, string>(true, new GetUserInfoResponse()
                        {
                            Id = customer.CompanyId,
                            Name = customer.CompanyName,
                            Role = RoleType.Customer,
                            Balance = customer.CompanyBalnce ?? 0
                        }, String.Empty);
                    break;
                case  RoleType.CustomerBranch:
                    var companyBranch = await _context.CompanyBranches.FindAsync(_userContext.Id);
                    if (companyBranch != null)
                        return new Tuple<bool, GetUserInfoResponse, string>(true, new GetUserInfoResponse()
                        {
                            Id = companyBranch.CompanyBranchId,
                            Name = companyBranch.CompanyBranchName,
                            Role = RoleType.CustomerBranch,
                            Balance = companyBranch.CompanyBranchBalnce ?? 0
                        }, String.Empty);
                    break;
                case RoleType.Supplier:
                    var petrolCompany = await _context.PetrolCompanies.FindAsync(_userContext.Id);
                    if(petrolCompany != null)
                        return new Tuple<bool, GetUserInfoResponse, string>(true, 
                            new GetUserInfoResponse(petrolCompany.PetrolCompanyId, RoleType.Supplier, petrolCompany.PetrolCompanyName, petrolCompany.PetrolCompanyBalnce ?? 0),
                            String.Empty);
                    break;
                case RoleType.SupplierBranch:
                    var supplier = await _context.PetroStations.FindAsync(_userContext.Id);
                    if(supplier != null)
                        return new Tuple<bool, GetUserInfoResponse, string>(true, 
                            new GetUserInfoResponse(supplier.StationId, RoleType.SupplierBranch, supplier.StationName, supplier.StationBalance ?? 0),
                            String.Empty);
                    break;
                case RoleType.Admin:
                    var admin = await _context.Emplyees.FindAsync(_userContext.Id);
                    if(admin != null)
                        return new Tuple<bool, GetUserInfoResponse, string>(true, 
                            new GetUserInfoResponse(admin.EmplyeeId, RoleType.Admin, admin.EmplyeeName, 0),
                            String.Empty);
                    break;
            }
            return new Tuple<bool, GetUserInfoResponse, string>(false, null, ApiMessages.ResourceNotFound);
        }
    }
}