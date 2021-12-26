using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PetroPay.Web.Controllers.Reports.OdometerHistories.Get
{
    public class OdometerHistoryGetHandler : ApiRequestHandler<OdometerHistoryGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public OdometerHistoryGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(OdometerHistoryGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);
            
            if(_userContext.Role == RoleType.CustomerBranch && request.CompanyBranchId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyBranchIdRequired);

            var query = _context.ViewOdometerHistories
                .AsQueryable();
            
            query = createQuery(query, request);
            
            OdometerHistoryGetResponse response = new OdometerHistoryGetResponse();
            response.TotalCount = await query.CountAsync();
            //response.SumOdometerHistory = await query.SumAsync(w => w.TransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<OdometerHistoryGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewOdometerHistory> createQuery(IQueryable<ViewOdometerHistory> query, OdometerHistoryGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            /*if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.C.Contains(request.CompanyName));
            }*/
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
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                //DateTime dateTimeFrom = Convert.ToDateTime(request.DateFrom);
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.OdometerRecordDate.HasValue && w.OdometerRecordDate.Value >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                //DateTime dateTimeTo = Convert.ToDateTime(request.DateTo);
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.OdometerRecordDate.HasValue && w.OdometerRecordDate.Value <= dateTimeTo);
            }
            return query;
        }
    }
}
