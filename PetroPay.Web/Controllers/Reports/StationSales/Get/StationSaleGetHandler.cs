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
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Reports.StationSales.Get
{
    public class StationSaleGetHandler : ApiRequestHandler<StationSaleGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public StationSaleGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(StationSaleGetRequest request)
        {
            if(_userContext.Role == RoleType.Supplier && request.StationWorkerId == null)
                return ActionResult.Error(ApiMessages.PetroStationMessage.IdRequired);
            
            var query = _context.ViewStationSales.OrderByDescending(w => w.SumInvoiceDataTime)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            StationSaleGetResponse response = new StationSaleGetResponse();
            response.TotalCount = await query.CountAsync();

            query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<StationSaleGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewStationSale> createQuery(IQueryable<ViewStationSale> query, StationSaleGetRequest request)
        {
            
            if (request.StationWorkerId.HasValue)
            {
                query = query.Where(w => w.StationWorkerId == request.StationWorkerId);
            }
            if (!string.IsNullOrEmpty(request.StationWorkerFname))
            {
                query = query.Where(w => w.StationWorkerFname.Contains(request.StationWorkerFname));
            }
            if (!string.IsNullOrEmpty(request.InvoiceFuelType))
            {
                query = query.Where(w => w.InvoiceFuelType.Contains(request.InvoiceFuelType));
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeFrom))
            {
                //DateTime dateTime = Convert.ToDateTime(request.InvoiceDataTimeFrom);
                query = query.Where(w => String.Compare(w.SumInvoiceDataTime, request.InvoiceDataTimeFrom) > 0);
                /*DbFunctions dfunc = null;
                query = query.Where(w => SqlServerDbFunctionsExtensions.SmallDateTimeFromParts(
                    dfunc,
                    Convert.ToInt32(w.SumInvoiceDataTime.Split("//").GetValue(2)),
                    Convert.ToInt32(w.SumInvoiceDataTime.Split("//")[1]),
                    Convert.ToInt32(w.SumInvoiceDataTime.Split("//")[0]), 0 , 0) <= dateTime);*/
            }
            if (!string.IsNullOrEmpty(request.InvoiceDataTimeTo))
            {
                query = query.Where(w => String.Compare(w.SumInvoiceDataTime, request.InvoiceDataTimeTo) < 0);
            }
            
            return query;

        }
    }
}
