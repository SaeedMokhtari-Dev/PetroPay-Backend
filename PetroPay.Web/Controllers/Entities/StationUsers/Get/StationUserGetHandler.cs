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

namespace PetroPay.Web.Controllers.Entities.StationUsers.Get
{
    public class StationUserGetHandler : ApiRequestHandler<StationUserGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public StationUserGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(StationUserGetRequest request)
        {
            if (!request.StationCompanyId.HasValue && _userContext.Role == RoleType.Supplier)
                request.StationCompanyId = _userContext.Id;
            
            if (!request.StationId.HasValue && _userContext.Role == RoleType.SupplierBranch)
                request.StationId = _userContext.Id;
            
            var query = _context.StationUsers.Include(w => w.Station)
                .OrderByDescending(w => w.StationWorkerId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            if (request.StationCompanyId.HasValue)
                query = query.Where(w =>
                    w.StationId.HasValue && w.Station.PetrolCompanyId.HasValue &&
                    w.Station.PetrolCompanyId.Value == request.StationCompanyId.Value);
            if (request.StationId.HasValue)
                query = query.Where(w => w.StationId.HasValue && w.StationId.Value == request.StationId.Value);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<StationUserGetResponseItem>>(result);

            StationUserGetResponse response = new StationUserGetResponse();
            response.TotalCount = await _context.StationUsers.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
