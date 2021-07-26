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

namespace PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get
{
    public class CompanyBranchStatementGetHandler : ApiRequestHandler<CompanyBranchStatementGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CompanyBranchStatementGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CompanyBranchStatementGetRequest request)
        {
            if(_userContext.Role == RoleType.Supplier)
                return ActionResult.Error(ApiMessages.Forbidden);
            if (_userContext.Role == RoleType.Customer && request.CompanyId == null)
                request.CompanyId = _userContext.Id;
            
            var query = _context.ViewCompanyBranchStatements.OrderByDescending(w => w.TransactionDateTime)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            CompanyBranchStatementGetResponse response = new CompanyBranchStatementGetResponse();
            response.TotalCount = await query.CountAsync();
            response.SumCompanyBranchStatement = await query.SumAsync(w => w.SumTransAmount ?? 0);

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CompanyBranchStatementGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewCompanyBranchStatement> createQuery(IQueryable<ViewCompanyBranchStatement> query, CompanyBranchStatementGetRequest request)
        {
            
            if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyId == request.CompanyId);
            }
            
            if (request.BranchId.HasValue)
            {
                query = query.Where(w => w.CompanyBranchId == request.BranchId);
            }
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                query = query.Where(w => String.Compare(w.TransactionDateTime, request.DateFrom) >= 0);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                query = query.Where(w => String.Compare(w.TransactionDateTime, request.DateTo) <= 0);
            }
            return query;

        }
    }
}
