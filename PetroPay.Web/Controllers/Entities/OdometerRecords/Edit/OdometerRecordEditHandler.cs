using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
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

            var lastOdometer = await _context.OdometerRecords.OrderByDescending(w => w.OdometerRecordDate)
                .FirstOrDefaultAsync(w => w.OdometerRecordId != editOdometerRecord.OdometerRecordId && 
                                          w.CarId.HasValue && w.CarId.Value == request.CarId);

            if (lastOdometer != null)
            {
                /*if (lastOdometer.OdometerRecordDate.HasValue)
                {
                    DateDiff dateDiff = new DateDiff(lastOdometer.OdometerRecordDate.Value, 
                        DateTime.ParseExact(request.OdometerRecordDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture));
                    if (dateDiff.Months < 1)
                    {
                        return ActionResult.Error(ApiMessages.OdometerRecordMessage.AtLeastOneMonth);
                    }
                }*/

                if ((lastOdometer.OdometerValue ?? 0) >= (request.OdometerValue ?? 0))
                {
                    return ActionResult.Error(ApiMessages.OdometerRecordMessage.NewRecordShouldBeGreaterThanPreviousRecord);
                }
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