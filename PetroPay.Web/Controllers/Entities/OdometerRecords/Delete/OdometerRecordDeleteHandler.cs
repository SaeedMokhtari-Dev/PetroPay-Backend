using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Delete
{
    public class OdometerRecordDeleteHandler : ApiRequestHandler<OdometerRecordDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public OdometerRecordDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordDeleteRequest request)
        {
            OdometerRecord odometerRecord = await _context.OdometerRecords
                .FindAsync(request.OdometerRecordId);

            if (odometerRecord == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.OdometerRecords.Remove(odometerRecord);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.OdometerRecordMessage.DeletedSuccessfully);
        }
    }
}
