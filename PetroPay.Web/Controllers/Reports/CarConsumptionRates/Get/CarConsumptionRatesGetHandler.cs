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
            /*if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = Convert.ToDateTime(request.DateFrom);
                query = query.Where(w => w.Date >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = Convert.ToDateTime(request.DateTo);
                query = query.Where(w => w.Date <= dateTimeTo);
            }*/
            return query;

        }
    }
}
