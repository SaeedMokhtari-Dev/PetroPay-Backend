using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Reports.CarTransactions.Get;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Cars.Get
{
    public class CarGetHandler : ApiRequestHandler<CarGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarGetRequest request)
        {
            if (!request.CompanyId.HasValue && _userContext.Role != RoleType.Admin)
                request.CompanyId = _userContext.Id;
            
            var query = _context.Cars.Include(w => w.CompanyBarnch)
                .ThenInclude(w => w.Company)
                .OrderByDescending(w => w.CarId)
                .AsQueryable();

            query = createQuery(query, request);
            CarGetResponse response = new CarGetResponse();
            response.TotalCount = await query.CountAsync();

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<Car> createQuery(IQueryable<Car> query, CarGetRequest request)
        {
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyBarnch.CompanyId == request.CompanyId.Value);
            }
            if (request.CompanyBranchId.HasValue)
            {
                query = query.Where(w => w.CompanyBarnchId == request.CompanyBranchId.Value);
            }
            if (request.NeedActivation)
            {
                query = query.Where(w => string.IsNullOrEmpty(w.CarNfcCode.Trim()) || w.CarNfcCode.Trim() == "0");
            }
            return query;

        }
    }
}
