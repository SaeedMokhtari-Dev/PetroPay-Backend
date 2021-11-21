using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetrolPrices.List
{
    public class PetrolPriceListHandler : ApiRequestHandler<PetrolPriceListRequest>
    {
        private readonly PetroPayContext _context;
        
        public PetrolPriceListHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(PetrolPriceListRequest request)
        {
            var query = _context.PetrolPrices.AsQueryable();

            var result = await query.Select(w => new PetrolPriceListResponseItem()
                {
                    Key = w.PetrolPriceId,
                    PetrolPrice1 = w.PetrolPrice1,
                    PetrolPriceType = w.PetrolPriceType
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}