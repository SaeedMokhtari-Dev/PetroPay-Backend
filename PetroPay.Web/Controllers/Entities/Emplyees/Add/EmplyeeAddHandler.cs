using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Add
{
    public class EmplyeeAddHandler : ApiRequestHandler<EmplyeeAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public EmplyeeAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmplyeeAddRequest request)
        {
            Emplyee emplyee = await AddEmplyee(request);
            
            return ActionResult.Ok(ApiMessages.EmplyeeMessage.AddedSuccessfully);
        }
        
        private async Task<Emplyee> AddEmplyee(EmplyeeAddRequest request)
        {
            Emplyee emplyee = await _context.ExecuteTransactionAsync(async () =>
            {
                Emplyee newEmplyee = _mapper.Map<Emplyee>(request);
                if (!string.IsNullOrEmpty(request.EmplyeePhoto))
                {
                    request.EmplyeePhoto =
                        request.EmplyeePhoto.Remove(0, request.EmplyeePhoto.IndexOf(',') + 1);
                    newEmplyee.EmplyeePhoto =
                        request.EmplyeePhoto.ToCharArray().Select(Convert.ToByte).ToArray();
                }
                newEmplyee = (await _context.Emplyees.AddAsync(newEmplyee)).Entity;
                await _context.SaveChangesAsync();

                return newEmplyee;
            });
            return emplyee;
        }
    }
}