using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailHandler : ApiRequestHandler<MenuDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public MenuDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuDetailRequest request)
        {
            Menu menu = await _context.Menus
                .FindAsync(request.MenuId);

            if (menu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            MenuDetailResponse response = _mapper.Map<MenuDetailResponse>(menu);
            
            return ActionResult.Ok(response);
        }
    }
}
