using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddHandler : ApiRequestHandler<MenuAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public MenuAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuAddRequest request)
        {
            Menu menu = await AddMenu(request);
            
            return ActionResult.Ok(ApiMessages.MenuMessage.AddedSuccessfully);
        }
        
        private async Task<Menu> AddMenu(MenuAddRequest request)
        {
            Menu menu = await _context.ExecuteTransactionAsync(async () =>
            {
                Menu newMenu = _mapper.Map<Menu>(request);
                newMenu = (await _context.Menus.AddAsync(newMenu)).Entity;
                await _context.SaveChangesAsync();

                return newMenu;
            });
            return menu;
        }
    }
}