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
            foreach (var employeeMenu in withParents)
            {
                int parentId = employeeMenu.Menu.ParentId ?? 0;
                if (menus.All(w => w.MenuId != parentId))
                {
                    var parent = await _context.Menus.FirstAsync(w => w.Id == parentId);
                    if (parent != null) menus.Add(new EmployeeMenu()
                    {
                        Id = (-1) * new Random(1000).Next(Int32.MaxValue),
                        Menu = parent
                    });
                }
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
