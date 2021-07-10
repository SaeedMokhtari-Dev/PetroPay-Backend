using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Detail
{
    public class OdometerRecordDetailHandler : ApiRequestHandler<OdometerRecordDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public OdometerRecordDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordDetailRequest request)
        {
            OdometerRecord odometerRecord = await _context.OdometerRecords
                .FindAsync(request.OdometerRecordId);

            if (odometerRecord == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            OdometerRecordDetailResponse response = _mapper.Map<OdometerRecordDetailResponse>(odometerRecord);
            
            return ActionResult.Ok(response);
        }
    }
}
