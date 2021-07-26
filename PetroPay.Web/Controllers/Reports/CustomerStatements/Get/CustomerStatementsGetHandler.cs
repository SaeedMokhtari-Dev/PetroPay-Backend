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

namespace PetroPay.Web.Controllers.Reports.CustomerStatements.Get
{
    public class CustomerStatementGetHandler : ApiRequestHandler<CustomerStatementGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CustomerStatementGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CustomerStatementGetRequest request)
        {
            if(_userContext.Role == RoleType.Supplier)
                return ActionResult.Error(ApiMessages.Forbidden);
            if (_userContext.Role == RoleType.Customer && request.CompanyId == null)
                request.CompanyId = _userContext.Id;
            
            var query = _context.ViewCustomerStatements.OrderByDescending(w => w.TransactionDataTime)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CustomerStatementGetResponse response = new CustomerStatementGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumCustomerStatement = await query.SumAsync(w => w.SumTransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CustomerStatementGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCustomerStatement> createQuery(IQueryable<ViewCustomerStatement> query, CustomerStatementGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            if (!string.IsNullOrEmpty(request.CompanyName))
            {
                query = query.Where(w => w.CompanyName.Contains(request.CompanyName));
            }
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                query = query.Where(w => String.Compare(w.TransactionDataTime, request.DateFrom) >= 0);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                query = query.Where(w => String.Compare(w.TransactionDataTime, request.DateTo) <= 0);
            }
            return query;

        }
    }
}
