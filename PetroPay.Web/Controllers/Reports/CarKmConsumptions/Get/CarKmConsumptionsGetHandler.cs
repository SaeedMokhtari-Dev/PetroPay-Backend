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

namespace PetroPay.Web.Controllers.Reports.CarKmConsumptions.Get
{
    public class CarKmConsumptionGetHandler : ApiRequestHandler<CarKmConsumptionGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarKmConsumptionGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarKmConsumptionGetRequest request)
        {
            /*if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);*/
            
            var query = _context.ViewCarKmConsumptions
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CarKmConsumptionGetResponse response = new CarKmConsumptionGetResponse();
            response.TotalCount = await query.CountAsync();
            //response.SumCarKmConsumption = await query.SumAsync(w => w.TransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarKmConsumptionGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCarKmConsumption> createQuery(IQueryable<ViewCarKmConsumption> query, CarKmConsumptionGetRequest request)
        {
            if (request.CarId.HasValue)
            {
                query = query.Where(w => w.CarId == request.CarId);
            }
            /*if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }*/
            /*if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.C.Contains(request.CompanyName));
            }*/
            /*if (!string.IsNullOrEmpty(request.CarIdNumber))
            {
                query = query.Where(w => w.CarIdNumber.Contains(request.CarIdNumber));
            }*/
            /*if (request.CompanyBranchId.HasValue)
            {
                query = query.Where(w => w.CompanyBranchId == request.CompanyBranchId);
            }
            if (!string.IsNullOrEmpty(request.CompanyBranchName))
            {
                query = query.Where(w => w.CompanyBranchName.Contains(request.CompanyBranchName));
            }*/
            /*if (!string.IsNullOrEmpty(request.TransDateFrom))
            {
                DateTime dateTimeFrom = Convert.ToDateTime(request.TransDateFrom);
                query = query.Where(w => w.TransDate >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.TransDateTo))
            {
                DateTime dateTimeTo = Convert.ToDateTime(request.TransDateTo);
                query = query.Where(w => w.TransDate <= dateTimeTo);
            }*/
            return query;

        }
    }
}
