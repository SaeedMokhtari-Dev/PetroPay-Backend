using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Branches.Delete
{
    public class BranchDeleteHandler : ApiRequestHandler<BranchDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BranchDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BranchDeleteRequest request)
        {
            CompanyBranch branch = await _context.CompanyBranches
                .FindAsync(request.BranchId);

            if (branch == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.CompanyBranches.Remove(branch);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.BranchMessage.DeletedSuccessfully);
        }
    }
}
