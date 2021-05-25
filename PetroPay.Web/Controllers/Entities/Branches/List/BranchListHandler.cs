using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Branches.List
{
    public class BranchListHandler : ApiRequestHandler<BranchListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public BranchListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(BranchListRequest request)
        {
            if (!request.CompanyId.HasValue && _userContext.Role != RoleType.Admin)
                request.CompanyId = _userContext.Id;
            
            var query = _context.CompanyBranches
                .Where(e => e.CompanyBranchActiva.HasValue && e.CompanyBranchActiva.Value)
                .OrderBy(w => w.CompanyBranchId)
                .AsQueryable();

            if (request.CompanyId.HasValue)
                query = query.Where(e => e.CompanyId.HasValue && e.CompanyId.Value == request.CompanyId);
            
            var response = await query.Select(w =>
            new BranchListResponseItem() {
                Key = w.CompanyBranchId, 
                Title = w.CompanyBranchName
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
