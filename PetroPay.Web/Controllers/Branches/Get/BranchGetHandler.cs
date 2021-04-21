using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Branches.Get
{
    public class BranchGetHandler : ApiRequestHandler<BranchGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BranchGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BranchGetRequest request)
        {
            var query = _context.CompanyBranches
                .Where(e => e.CompanyId.HasValue && e.CompanyId.Value == request.CompanyId)
                .OrderBy(w => w.CompanyBranchId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<BranchGetResponseItem>>(result);

            BranchGetResponse response = new BranchGetResponse();
            response.TotalCount = await _context.Companies.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
