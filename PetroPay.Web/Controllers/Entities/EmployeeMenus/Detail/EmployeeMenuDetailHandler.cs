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

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Detail
{
    public class EmployeeMenuDetailHandler : ApiRequestHandler<EmployeeMenuDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public EmployeeMenuDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmployeeMenuDetailRequest request)
        {
            List<EmployeeMenu> employeeMenus = await _context.EmployeeMenus
                .Where(w => w.EmployeeId == request.EmployeeId).ToListAsync();

            if (employeeMenus == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            var response = new EmployeeMenuDetailResponse()
            {
                EmployeeId = request.EmployeeId,
                MenuIds = employeeMenus.Select(w => w.MenuId).ToList()
            };
            
            return ActionResult.Ok(response);
        }
    }
}
