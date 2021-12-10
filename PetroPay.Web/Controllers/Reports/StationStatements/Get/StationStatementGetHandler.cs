using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Reports.StationStatements.Get
{
    public class StationStatementGetHandler : ApiRequestHandler<StationStatementGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public StationStatementGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(StationStatementGetRequest request)
        {
            if (_userContext.Role == RoleType.Supplier && request.CompanyId == null)
                request.CompanyId = _userContext.Id;

            if (_userContext.Role == RoleType.SupplierBranch && request.StationId == null)
                request.StationId = _userContext.Id;
            
            var query = _context.ViewStationStatements.OrderByDescending(w => w.InvoiceDataTime)
                .AsQueryable();
            
            query = await createQuery(query, request);
            
            StationStatementGetResponse response = new StationStatementGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumTransAmount = await query.SumAsync(w => w.SumTransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<StationStatementGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private async Task<IQueryable<ViewStationStatement>> createQuery(IQueryable<ViewStationStatement> query, StationStatementGetRequest request)
        {
            if (request.CompanyId.HasValue)
            {
                List<int> stationIds = await _context.PetroStations.Where(w => w.PetrolCompanyId.HasValue
                                                                               && w.PetrolCompanyId.Value ==
                                                                               request.CompanyId.Value)
                    .Select(w => w.StationId).ToListAsync();
                query = query.Where(w => stationIds.Contains(request.StationId.Value));
            }
            if (request.StationId.HasValue)
            {
                query = query.Where(w => w.StationId == request.StationId);
            }
            if (!string.IsNullOrEmpty(request.StationName))
            {
                query = query.Where(w => EF.Functions.Like(w.StationName, $"%{request.StationName}%"));
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeFrom))
            {
                query = query.Where(w => String.Compare(w.InvoiceDataTime, request.InvoiceDataTimeFrom.ReverseDate()) >= 0);
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeTo))
            {
                query = query.Where(w => String.Compare(w.InvoiceDataTime, request.InvoiceDataTimeTo.ReverseDate()) <= 0);
            }
            
            return query;

        }
    }
}
