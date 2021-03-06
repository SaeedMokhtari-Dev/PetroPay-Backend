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

namespace PetroPay.Web.Controllers.Entities.Branches.Get
{
    public class BranchGetHandler : ApiRequestHandler<BranchGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public BranchGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(BranchGetRequest request)
        {
            if (!request.CompanyId.HasValue && _userContext.Role != RoleType.Admin)
                request.CompanyId = _userContext.Id;
            
            var query = _context.CompanyBranches
                .Where(e => e.CompanyId.HasValue && e.CompanyId.Value == request.CompanyId)
                .OrderBy(w => w.CompanyBranchId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<BranchGetResponseItem>>(result);

            BranchGetResponse response = new BranchGetResponse();
            response.TotalCount = await _context.CompanyBranches.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
