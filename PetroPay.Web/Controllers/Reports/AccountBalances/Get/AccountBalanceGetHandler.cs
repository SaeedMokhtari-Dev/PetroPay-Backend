using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Get
{
    public class AccountBalanceGetHandler : ApiRequestHandler<AccountBalanceGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public AccountBalanceGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AccountBalanceGetRequest request)
        {
            var query = _context.ViewAccountBalances.OrderBy(w => w.AccountId)
                .AsQueryable();
            
            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<AccountBalanceGetResponseItem>>(result);

            AccountBalanceGetResponse response = new AccountBalanceGetResponse();
            response.TotalCount = await _context.ViewAccountBalances.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
