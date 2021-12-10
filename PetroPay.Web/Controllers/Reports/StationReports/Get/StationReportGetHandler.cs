using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Reports.StationReports.Get
{
    public class StationReportGetHandler : ApiRequestHandler<StationReportGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public StationReportGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(StationReportGetRequest request)
        {
            if(_userContext.Role == RoleType.Supplier && request.CompanyId == null)
                request.CompanyId = _userContext.Id;
            
            if(_userContext.Role == RoleType.SupplierBranch && request.StationId == null)
                request.StationId = _userContext.Id;
            
            var query = _context.ViewStationReports.OrderByDescending(w => w.InvoiceDataTime)
                .AsQueryable();
            
            query = await createQuery(query, request);
            
            StationReportGetResponse response = new StationReportGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumInvoiceAmount = await query.SumAsync(w => w.InvoiceAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<StationReportGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private async Task<IQueryable<ViewStationReport>> createQuery(IQueryable<ViewStationReport> query, StationReportGetRequest request)
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
                query = query.Where(w => w.StationId == request.StationId.Value);
            }
            if (request.StationWorkerId.HasValue)
            {
                query = query.Where(w => w.StationWorkerId == request.StationWorkerId.Value);
            }
            if (request.InvoiceId.HasValue)
            {
                query = query.Where(w => w.InvoiceId == request.InvoiceId.Value);
            }
            if (request.ServiceId.HasValue)
            {
                query = query.Where(w => w.ServiceId == request.ServiceId.Value);
            }
            if (!string.IsNullOrEmpty(request.StationWorkerFname))
            {
                query = query.Where(w => w.StationWorkerFname.Contains(request.StationWorkerFname));
            }
            if (!string.IsNullOrEmpty(request.ServiceArDescription))
            {
                query = query.Where(w => w.ServiceArDescription.Contains(request.ServiceArDescription));
            }
            if (!string.IsNullOrEmpty(request.PaymentMethodName))
            {
                query = query.Where(w => w.PaymentMethodName.Contains(request.PaymentMethodName));
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeFrom))
            {
                DateTime dateTimeFrom = Convert.ToDateTime(request.InvoiceDataTimeFrom);
                query = query.Where(w => w.InvoiceDataTime >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeTo))
            {
                DateTime dateTimeTo = Convert.ToDateTime(request.InvoiceDataTimeTo);
                query = query.Where(w => w.InvoiceDataTime <= dateTimeTo);
            }
            return query;

        }
    }
}
