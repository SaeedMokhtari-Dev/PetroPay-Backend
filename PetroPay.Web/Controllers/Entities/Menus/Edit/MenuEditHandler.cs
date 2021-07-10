using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Menus.Edit
{
    public class MenuEditHandler : ApiRequestHandler<MenuEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public MenuEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuEditRequest request)
        {
            Menu editMenu = await _context.Menus
                .FindAsync(request.MenuId);

            if (editMenu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditMenu(editMenu, request);
            return ActionResult.Ok(ApiMessages.MenuMessage.EditedSuccessfully);
        }

        private async Task EditMenu(Menu editMenu, MenuEditRequest request)
        {
            _mapper.Map(request, editMenu);

            await _context.SaveChangesAsync();
        }
    }
}