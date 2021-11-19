using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
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

namespace PetroPay.Web.Controllers.Reports.InvoiceSummary.Get
{
    public class InvoiceSummaryGetHandler : ApiRequestHandler<InvoiceSummaryGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public InvoiceSummaryGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(InvoiceSummaryGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);
            
            if(_userContext.Role == RoleType.CustomerBranch && request.CompanyBranchId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyBranchIdRequired);
            
            var query = _context.ViewInvoicesSummaries.OrderByDescending(w => w.InvoiceDataTime)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            InvoiceSummaryGetResponse response = new InvoiceSummaryGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumInvoiceAmount = await query.SumAsync(w => w.InvoiceAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<InvoiceSummaryGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewInvoicesSummary> createQuery(IQueryable<ViewInvoicesSummary> query, InvoiceSummaryGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            if (request.InvoiceId.HasValue)
            {
                query = query.Where(w => w.InvoiceId == request.InvoiceId);
            }
            if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.CompanyName.Contains(request.CompanyName));
            }
            if (!string.IsNullOrEmpty(request.CarIdNumber))
            {
                query = query.Where(w => w.CarIdNumber.Contains(request.CarIdNumber));
            }
            if (request.CompanyBranchId.HasValue)
            {
                query = query.Where(w => w.CompanyBranchId == request.CompanyBranchId);
            }
            if (!string.IsNullOrEmpty(request.CompanyBranchName))
            {
                query = query.Where(w => w.CompanyBranchName.Contains(request.CompanyBranchName));
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeFrom))
            {
                //DateTime dateTimeFrom = Convert.ToDateTime(request.InvoiceDataTimeFrom);
                DateTime dateTimeFrom = DateTime.ParseExact(request.InvoiceDataTimeFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.InvoiceDataTime >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeTo))
            {
                //DateTime dateTimeTo = Convert.ToDateTime(request.InvoiceDataTimeTo);
                DateTime dateTimeTo = DateTime.ParseExact(request.InvoiceDataTimeTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.InvoiceDataTime <= dateTimeTo);
            }
            if (!string.IsNullOrEmpty(request.ServiceDescription))
            {
                query = query.Where(w => w.ServiceArDescription.Contains(request.ServiceDescription)
                || w.ServiceEnDescription.Contains(request.ServiceDescription));
            }
            return query;

        }
    }
}
