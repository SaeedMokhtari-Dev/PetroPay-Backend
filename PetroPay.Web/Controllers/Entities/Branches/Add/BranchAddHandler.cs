using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Branches.Add
{
    public class BranchAddHandler : ApiRequestHandler<BranchAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;
        
        public BranchAddHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            this._context = context;
            this._mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(BranchAddRequest request)
        {
            var isUsernameDuplicate =
                _context.CompanyBranches.Any(w => w.CompanyBranchAdminUserName.Trim().ToUpper() == request.CompanyBranchAdminUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }
            
            var isEmailDuplicate =
                _context.CompanyBranches.Any(w => w.CompanyBranchAdminEmail.Trim().ToUpper() == request.CompanyBranchAdminEmail.Trim().ToUpper());
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateEmail);
            }
            
            CompanyBranch branch = await AddBranch(request);
            
            return ActionResult.Ok(ApiMessages.BranchMessage.AddedSuccessfully);
        }
        
        private async Task<CompanyBranch> AddBranch(BranchAddRequest request)
        {
            CompanyBranch branch = await _context.ExecuteTransactionAsync(async () =>
            {
                CompanyBranch newBranch = _mapper.Map<CompanyBranch>(request);
                
                AccountMaster accountMaster = new AccountMaster();
                accountMaster.AccountName = request.CompanyBranchName;
                accountMaster.AccountTaype = "branch";

                newBranch.Account = accountMaster;
                
                newBranch = (await _context.CompanyBranches.AddAsync(newBranch)).Entity;
                await _context.SaveChangesAsync();

                return newBranch;
            });
            return branch;
        }
    }
}