using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Menus.Active
{
    public class MenuActiveHandler : ApiRequestHandler<MenuActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public MenuActiveHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuActiveRequest request)
        {
            Menu menu = await _context.Menus
                .FindAsync(request.MenuId);

            if (menu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            menu.IsActive = true;

            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.MenuMessage.ActivatedSuccessfully);
        }
    }
}
