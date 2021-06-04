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

namespace PetroPay.Web.Controllers.Entities.Companies.List
{
    public class CompanyListHandler : ApiRequestHandler<CompanyListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CompanyListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CompanyListRequest request)
        {
            if (_userContext.Role != RoleType.Admin)
                return ActionResult.Error(ApiMessages.Forbidden);
            
            var query = _context.Companies
                .OrderBy(w => w.CompanyId)
                .AsQueryable();

            var response = await query.Select(w =>
            new CompanyListResponseItem() {
                Key = w.CompanyId, 
                Title = w.CompanyName,
                Balance = w.CompanyBalnce ?? 0
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
