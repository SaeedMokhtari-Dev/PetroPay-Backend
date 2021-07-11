using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Add
{
    public class EmployeeMenuAddHandler : ApiRequestHandler<EmployeeMenuAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public EmployeeMenuAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmployeeMenuAddRequest request)
        {
            Emplyee editEmployee = await _context.Emplyees.Include(w => w.EmployeeMenus)
                .SingleOrDefaultAsync(w => w.EmplyeeId == request.EmployeeId);

            if (editEmployee == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            await AddEmployeeMenu(editEmployee, request);
            
            return ActionResult.Ok(ApiMessages.EmployeeMenuMessage.AddedSuccessfully);
        }
        
        private async Task AddEmployeeMenu(Emplyee editEmployee, EmployeeMenuAddRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                List<int> menuIds = editEmployee.EmployeeMenus.Select(w => w.MenuId).ToList();
                
                var shouldRemoveMenuIds = menuIds.Except(request.MenuIds).ToList();
                foreach (var shouldRemoveMenuId in shouldRemoveMenuIds)
                {
                    var removeEntity = editEmployee.EmployeeMenus.Single(w => w.MenuId == shouldRemoveMenuId);
                    _context.Remove(removeEntity);
                }
                
                var shouldAdded = request.MenuIds.Except(menuIds).ToList();
                foreach (var w in shouldAdded)
                {
                    editEmployee.EmployeeMenus.Add(new EmployeeMenu()
                    {
                        MenuId = w,
                        EmployeeId = editEmployee.EmplyeeId
                    });
                }
                await _context.SaveChangesAsync();
            });
        }
    }
}