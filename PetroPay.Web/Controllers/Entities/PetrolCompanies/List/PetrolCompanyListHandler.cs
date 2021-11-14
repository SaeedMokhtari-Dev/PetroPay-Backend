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
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.List
{
    public class PetrolCompanyListHandler : ApiRequestHandler<PetrolCompanyListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public PetrolCompanyListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyListRequest request)
        {
            if (_userContext.Role != RoleType.Admin)
                return ActionResult.Error(ApiMessages.Forbidden);
            
            var query = _context.PetrolCompanies
                .OrderBy(w => w.PetrolCompanyId)
                .AsQueryable();

            var response = await query.Select(w =>
            new PetrolCompanyListResponseItem() {
                Key = w.PetrolCompanyId, 
                Title = w.PetrolCompanyName,
                Balance = w.PetrolCompanyBalnce ?? 0
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
