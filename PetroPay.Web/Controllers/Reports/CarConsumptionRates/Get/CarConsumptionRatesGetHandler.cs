using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Reports.CarConsumptionRates.Get
{
    public class CarConsumptionRateGetHandler : ApiRequestHandler<CarConsumptionRateGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarConsumptionRateGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarConsumptionRateGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);
            
            var query = _context.ViewCarConsumptionRates
                .AsQueryable();
            
            int spResult = await runSP(request.DateFrom, request.DateTo);
            
            query = createQuery(query, request);
            
            CarConsumptionRateGetResponse response = new CarConsumptionRateGetResponse();
            response.TotalCount = await query.CountAsync();
            //response.SumCarConsumptionRate = await query.SumAsync(w => w.TransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarConsumptionRateGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private async Task<int> runSP(string requestDateTimeFrom, string requestDateTimeTo)
        {
            try
            {
                StringBuilder query = new StringBuilder("exec spView_odometer_between_date ");
                if (!string.IsNullOrEmpty(requestDateTimeFrom) || !string.IsNullOrEmpty(requestDateTimeTo))
                    query.Append($"'{requestDateTimeFrom?.ReverseDate().Replace('/', '-')}', '{requestDateTimeTo?.ReverseDate().Replace('/', '-')}'");
                return await _context.Database.ExecuteSqlRawAsync(query.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        private IQueryable<ViewCarConsumptionRate> createQuery(IQueryable<ViewCarConsumptionRate> query, CarConsumptionRateGetRequest request)
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
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.DateMin >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.DateMax <= dateTimeTo);
            }
            return query;

        }
    }
}
