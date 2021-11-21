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
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Get
{
    public class PetropayAccountGetHandler : ApiRequestHandler<PetropayAccountGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetropayAccountGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetropayAccountGetRequest request)
        {
            var petropayAccounts = await _context.PetropayAccounts
                .Select(w => w.AccountId).ToListAsync();
            var query = _context.TransAccounts.Include(w => w.Account)
                .Where(w => petropayAccounts.Contains(w.AccountId)).OrderByDescending(w => w.TransId)
                .AsQueryable();

            query = createQuery(query, request);
            
            PetropayAccountGetResponse response = new PetropayAccountGetResponse();
            response.TotalCount = await query.CountAsync();
            
            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
                    /*.Select(w => new PetropayAccountGetResponseItem()
            {
                Key = w.TransId,
                AccountId = w.AccountId,
                AccountName = w.AccountId.HasValue ? w.Account.AccountName : string.Empty,
                TransAmount = w.TransAmount ?? 0,
                TransDate = w.TransDate.HasValue ? w.TransDate.Value.ToString(DateTimeConstants.DateTimeFormat) : string.Empty,
                TransDocument = 
            })*/
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetropayAccountGetResponseItem>>(result);

            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<TransAccount> createQuery(IQueryable<TransAccount> query, PetropayAccountGetRequest request)
        {
            if (request.PetropayAccountId.HasValue)
            {
                query = query.Where(w => w.AccountId == request.PetropayAccountId);
            }
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.TransDate.HasValue && w.TransDate.Value >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture).AddDays(1);
                query = query.Where(w => w.TransDate.HasValue && w.TransDate.Value <= dateTimeTo);
            }
            return query;

        }
    }
}
