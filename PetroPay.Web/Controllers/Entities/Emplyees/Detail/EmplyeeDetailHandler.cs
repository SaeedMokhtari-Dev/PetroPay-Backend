using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Detail
{
    public class EmplyeeDetailHandler : ApiRequestHandler<EmplyeeDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public EmplyeeDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmplyeeDetailRequest request)
        {
            Emplyee emplyee = await _context.Emplyees
                .FindAsync(request.EmployeesId);

            if (emplyee == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            EmplyeeDetailResponse response = _mapper.Map<EmplyeeDetailResponse>(emplyee);
            
            if (emplyee.EmplyeePhoto != null)
            {
                response.EmplyeePhoto = $"data:image/png;base64,{String.Join("", emplyee.EmplyeePhoto.Select(Convert.ToChar))}";
            }
            
            return ActionResult.Ok(response);
        }
    }
}
