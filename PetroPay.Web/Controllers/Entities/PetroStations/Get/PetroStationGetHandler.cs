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

namespace PetroPay.Web.Controllers.Entities.PetroStations.Get
{
    public class PetroStationGetHandler : ApiRequestHandler<PetroStationGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public PetroStationGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetroStationGetRequest request)
        {
            if (_userContext.Role == RoleType.Supplier && !request.PetroCompanyId.HasValue)
                request.PetroCompanyId = _userContext.Id; 
            
            var query = _context.PetroStations
                .Include(w => w.PetrolCompany)
                .OrderBy(w => w.StationId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            if(request.PetroCompanyId.HasValue)
                query = query.Where(w => w.PetrolCompanyId == request.PetroCompanyId.Value);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetroStationGetResponseItem>>(result);

            PetroStationGetResponse response = new PetroStationGetResponse();
            response.TotalCount = await _context.PetroStations.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
