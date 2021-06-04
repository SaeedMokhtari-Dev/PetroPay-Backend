using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.List
{
    public class PetropayAccountListHandler : ApiRequestHandler<PetropayAccountListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public PetropayAccountListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetropayAccountListRequest request)
        {
            var query = _context.PetropayAccounts.AsQueryable();
            if (request.JustPaymentMethodShow)
                query = query.Where(e => e.AccPaymentMethodShow == true);


            var result = await query.Select(w => new PetropayAccountListResponseItem()
                {
                    Key = w.AccId,
                    Title = w.AccName,
                    Balance = w.AccBalance ?? 0
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}