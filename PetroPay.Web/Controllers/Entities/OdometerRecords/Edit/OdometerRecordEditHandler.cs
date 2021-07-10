using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Edit
{
    public class OdometerRecordEditHandler : ApiRequestHandler<OdometerRecordEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public OdometerRecordEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordEditRequest request)
        {
            OdometerRecord editOdometerRecord = await _context.OdometerRecords
                .FindAsync(request.OdometerRecordId);

            if (editOdometerRecord == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditAuditingOdometerRecordOdometerRecordOdometerRecord(editOdometerRecord, request);
            return ActionResult.Ok(ApiMessages.OdometerRecordMessage.EditedSuccessfully);
        }

        private async Task EditAuditingOdometerRecordOdometerRecordOdometerRecord(OdometerRecord editOdometerRecord, OdometerRecordEditRequest request)
        {
            _mapper.Map(request, editOdometerRecord);
            await _context.SaveChangesAsync();
        }
    }
}