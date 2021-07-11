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

namespace PetroPay.Web.Controllers.Entities.Menus.Tree
{
    public class MenuTreeHandler : ApiRequestHandler<MenuTreeRequest>
    {
        private readonly PetroPayContext _context;
        
        public MenuTreeHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(MenuTreeRequest request)
        {   
            var menus = await _context.Menus
                .Where(w => w.IsActive)
                .OrderBy(w => w.DisplayOrder)
                .ToListAsync();

            var result = menus.Where(w => !w.ParentId.HasValue).Select(w => new MenuTreeResponse()
            {
                Key = w.Id,
                ArTitle = w.ArTitle,
                EnTitle = w.EnTitle,
                Items = menus.Where(e => e.ParentId.HasValue && e.ParentId.Value == w.Id)
                    .Select(e => new MenuTreeResponseItem()
                    {
                        Key = e.Id,
                        ArTitle = e.ArTitle,
                        EnTitle = e.EnTitle
                    }).ToList()
            }).ToList();
            
            return ActionResult.Ok(result);
        }
    }
}
