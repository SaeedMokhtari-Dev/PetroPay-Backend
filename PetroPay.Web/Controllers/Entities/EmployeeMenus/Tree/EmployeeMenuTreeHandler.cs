using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Tree
{
    public class EmployeeMenuTreeHandler : ApiRequestHandler<EmployeeMenuTreeRequest>
    {
        private readonly PetroPayContext _context;
        
        public EmployeeMenuTreeHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(EmployeeMenuTreeRequest request)
        {   
            var menus = await _context.EmployeeMenus.Include(w => w.Menu)
                .Where(w => w.Menu.IsActive && w.EmployeeId == request.EmployeeId)
                .OrderBy(w => w.Menu.DisplayOrder)
                .ToListAsync();

            var withParents = menus.Where(w => w.Menu.ParentId.HasValue).ToList();
            var parentIds = withParents.Where(w => w.Menu.ParentId.HasValue).Select(w => w.Menu.ParentId.Value).Distinct();
            var parents = await _context.Menus.Where(w => w.IsActive && parentIds.Contains(w.Id)).ToListAsync();
            foreach (var parent in parents)
            {
                menus.Add(new EmployeeMenu()
                {
                    Id = parent.Id,
                    MenuId = parent.Id,//(-1) * new Random(1000).Next(Int32.MaxValue),
                    Menu = parent
                });
            }
            
            var result = menus.Where(w => !w.Menu.ParentId.HasValue).Select(w => new EmployeeMenuTreeResponse()
            {
                Key = w.Id,
                ArTitle = w.Menu.ArTitle,
                EnTitle = w.Menu.EnTitle,
                UrlRoute = w.Menu.UrlRoute,
                Items = menus.Where(e => e.Menu.ParentId.HasValue && e.Menu.ParentId.Value == w.Menu.Id)
                    .Select(e => new EmployeeMenuTreeResponseItem()
                    {
                        Key = e.Id,
                        ArTitle = e.Menu.ArTitle,
                        EnTitle = e.Menu.EnTitle,
                        UrlRoute = e.Menu.UrlRoute
                    }).ToList()
            }).ToList();
            
            return ActionResult.Ok(result);
        }
    }
}
