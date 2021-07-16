using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Edit
{
    public class EmplyeeEditHandler : ApiRequestHandler<EmplyeeEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public EmplyeeEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmplyeeEditRequest request)
        {
            Emplyee editEmplyee = await _context.Emplyees
                .FindAsync(request.EmplyeeId);

            if (editEmplyee == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditAuditingEmplyeeEmplyeeEmplyee(editEmplyee, request);
            return ActionResult.Ok(ApiMessages.EmplyeeMessage.EditedSuccessfully);
        }

        private async Task EditAuditingEmplyeeEmplyeeEmplyee(Emplyee editEmplyee, EmplyeeEditRequest request)
        {
            _mapper.Map(request, editEmplyee);
            request.EmplyeePhoto =
                request.EmplyeePhoto.Remove(0, request.EmplyeePhoto.IndexOf(',') + 1);
            editEmplyee.EmplyeePhoto =
                request.EmplyeePhoto.ToCharArray().Select(Convert.ToByte).ToArray();
            await _context.SaveChangesAsync();
        }
    }
}