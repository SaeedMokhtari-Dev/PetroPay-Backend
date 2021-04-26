using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Branches.Edit
{
    public class BranchEditHandler : ApiRequestHandler<BranchEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public BranchEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BranchEditRequest request)
        {
            CompanyBranch editBranch = await _context.CompanyBranches
                .FindAsync(request.CompanyBranchId);

            if (editBranch == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            var isUsernameDuplicate =
                _context.CompanyBranches.Any(w => w.CompanyBranchAdminUserName.Trim().ToUpper() == request.CompanyBranchAdminUserName.Trim().ToUpper()
                                            && w.CompanyBranchId != request.CompanyBranchId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            await EditBranch(editBranch, request);
            return ActionResult.Ok(ApiMessages.BranchMessage.EditedSuccessfully);
        }

        private async Task EditBranch(CompanyBranch editBranch, BranchEditRequest request)
        {
            _mapper.Map(request, editBranch);

            await _context.SaveChangesAsync();
        }
    }
}