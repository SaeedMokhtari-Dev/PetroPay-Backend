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
            if (_userContext.Role == RoleType.CustomerBranch && !request.BranchId.HasValue)
                request.BranchId = _userContext.Id;
            var query = _context.ViewOdometerRecords
                .AsQueryable();

            if (request.CompanyId.HasValue)
                query = query.Where(w =>
                    w.CompanyId == request.CompanyId.Value);
            
            if (request.BranchId.HasValue)
                query = query.Where(w =>
                    w.CompanyBranchId == request.BranchId.Value);
            
            OdometerRecordGetResponse response = new OdometerRecordGetResponse();
            response.TotalCount = await query.CountAsync();
            
            if (!(request.ExportToFile.HasValue && request.ExportToFile.Value))
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<OdometerRecordGetResponseItem>>(result);

            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
