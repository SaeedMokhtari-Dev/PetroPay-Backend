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

namespace PetroPay.Web.Controllers.Reports.CarOdometerMins.Get
{
    public class CarOdometerMinGetHandler : ApiRequestHandler<CarOdometerMinGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarOdometerMinGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarOdometerMinGetRequest request)
        {
            /*if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);*/
            
            var query = _context.ViewCarOdometerMins
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CarOdometerMinGetResponse response = new CarOdometerMinGetResponse();
            response.TotalCount = await query.CountAsync();
            //response.SumCarOdometerMin = await query.SumAsync(w => w.TransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarOdometerMinGetResponseItem>>(result);
            response.Items = mappedResult;
            var carIds = response.Items.Select(w => w.CarId ?? 0).Distinct().ToList();
            var cars = await _context.Cars.Where(w => carIds.Contains(w.CarId)).Select(w => new
            {
                w.CarId,
                w.CarIdNumber
            }).ToListAsync();
            foreach (var carOdometerMinGetResponseItem in response.Items)
            {
                var car = cars.FirstOrDefault(w => w.CarId == carOdometerMinGetResponseItem.CarId);
                carOdometerMinGetResponseItem.CarIdNumber = car?.CarIdNumber;
            }
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCarOdometerMin> createQuery(IQueryable<ViewCarOdometerMin> query, CarOdometerMinGetRequest request)
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
