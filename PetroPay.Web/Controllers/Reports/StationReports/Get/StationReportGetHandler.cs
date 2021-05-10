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
            if(_userContext.Role == RoleType.Supplier && request.StationWorkerId == null)
                return ActionResult.Error(ApiMessages.PetroStationMessage.IdRequired);
            
            var query = _context.ViewStationReports.OrderByDescending(w => w.InvoiceDataTime)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            StationReportGetResponse response = new StationReportGetResponse();
            response.TotalCount = await query.CountAsync();

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<StationReportGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewStationReport> createQuery(IQueryable<ViewStationReport> query, StationReportGetRequest request)
        {
            
            if (request.StationWorkerId.HasValue)
            {
                query = query.Where(w => w.StationId == request.StationWorkerId);
            }
            if (!string.IsNullOrEmpty(request.StationWorkerFname))
            {
                query = query.Where(w => w.StationWorkerFname.Contains(request.StationWorkerFname));
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
