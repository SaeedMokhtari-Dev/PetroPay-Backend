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

namespace PetroPay.Web.Controllers.Entities.Menus.List
{
    public class MenuListHandler : ApiRequestHandler<MenuListRequest>
    {
        private readonly PetroPayContext _context;
        
        public MenuListHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(MenuListRequest request)
        {   
            var query = _context.Menus
                .Where(w => w.IsActive && !w.ParentId.HasValue)
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            var result = await query.Select(w => new MenuListResponse()
            {
                Key = w.Id,
                ArTitle = w.ArTitle,
                EnTitle = w.EnTitle
            }).ToListAsync();
            
            return ActionResult.Ok(result);
        }
    }
}
