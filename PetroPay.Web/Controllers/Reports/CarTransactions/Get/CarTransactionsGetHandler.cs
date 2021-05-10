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

namespace PetroPay.Web.Controllers.Reports.CarTransactions.Get
{
    public class CarTransactionGetHandler : ApiRequestHandler<CarTransactionGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarTransactionGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarTransactionGetRequest request)
        {
            if(_userContext.Role == RoleType.Customer && request.CompanyId == null)
                return ActionResult.Error(ApiMessages.BranchMessage.CompanyIdRequired);
            
            var query = _context.ViewCarTransactions
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CarTransactionGetResponse response = new CarTransactionGetResponse();
            response.TotalCount = await query.CountAsync();
            //response.SumCarTransaction = await query.SumAsync(w => w.TransAmount ?? 0);

            query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarTransactionGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCarTransaction> createQuery(IQueryable<ViewCarTransaction> query, CarTransactionGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.CompanyName.Contains(request.CompanyName));
            }
            if (!string.IsNullOrEmpty(request.CarIdNumber))
            {
                query = query.Where(w => w.CarIdNumber.Contains(request.CarIdNumber));
            }
            if (!string.IsNullOrEmpty(request.CompanyBranchName))
            {
                query = query.Where(w => w.CompanyBranchName.Contains(request.CompanyBranchName));
            }
            if (!string.IsNullOrEmpty(request.TransDateFrom))
            {
                DateTime dateTimeFrom = Convert.ToDateTime(request.TransDateFrom);
                query = query.Where(w => w.TransDate >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.TransDateTo))
            {
                DateTime dateTimeTo = Convert.ToDateTime(request.TransDateTo);
                query = query.Where(w => w.TransDate <= dateTimeTo);
            }
            return query;

        }
    }
}
