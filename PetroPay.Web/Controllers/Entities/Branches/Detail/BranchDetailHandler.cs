using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Branches.Detail
{
    public class BranchDetailHandler : ApiRequestHandler<BranchDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BranchDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BranchDetailRequest request)
        {
            CompanyBranch branch = await _context.CompanyBranches
                .FindAsync(request.BranchId);

            if (branch == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            BranchDetailResponse response = _mapper.Map<BranchDetailResponse>(branch);
            
            return ActionResult.Ok(response);
        }
    }
}
