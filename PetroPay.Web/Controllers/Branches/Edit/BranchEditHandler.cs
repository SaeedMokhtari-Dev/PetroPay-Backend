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

            /*var isEmailDuplicate =
                _context.Branchs.Any(w => w.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()
                                       && w.Id != request.BranchId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.Branch.EmailIsDuplicate);
            }*/

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