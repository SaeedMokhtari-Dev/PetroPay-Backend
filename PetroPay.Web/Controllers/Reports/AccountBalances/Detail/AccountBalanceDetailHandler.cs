using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Detail
{
    public class AccountBalanceDetailHandler : ApiRequestHandler<AccountBalanceDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public AccountBalanceDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AccountBalanceDetailRequest request)
        {
            ViewAccountBalance accountBalance = await _context.ViewAccountBalances
                .FindAsync(request.AccountBalancesId);

            if (accountBalance == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            AccountBalanceDetailResponse response = _mapper.Map<AccountBalanceDetailResponse>(accountBalance);
            
            return ActionResult.Ok(response);
        }
    }
}
