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

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    public class OdometerRecordGetHandler : ApiRequestHandler<OdometerRecordGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public OdometerRecordGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordGetRequest request)
        {
            if (_userContext.Role == RoleType.Customer && !request.CompanyId.HasValue)
                request.CompanyId = _userContext.Id;
            var query = _context.ViewOdometerRecords
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            if (request.CompanyId.HasValue)
                query = query.Where(w =>
                    w.CompanyId == request.CompanyId.Value);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<OdometerRecordGetResponseItem>>(result);

            OdometerRecordGetResponse response = new OdometerRecordGetResponse();
            response.TotalCount = await _context.OdometerRecords.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
