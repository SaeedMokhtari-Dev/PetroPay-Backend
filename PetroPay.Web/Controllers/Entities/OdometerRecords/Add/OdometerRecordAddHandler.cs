using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Add
{
    public class OdometerRecordAddHandler : ApiRequestHandler<OdometerRecordAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        
        public OdometerRecordAddHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            this._context = context;
            this._mapper = mapper;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordAddRequest request)
        {
            var lastOdometer = await _context.OdometerRecords.OrderByDescending(w => w.OdometerRecordDate)
                .FirstOrDefaultAsync(w => w.CarId.HasValue && w.CarId.Value == request.CarId);

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
            OdometerRecord odometerRecord = await AddOdometerRecord(request);
            
            return ActionResult.Ok(ApiMessages.OdometerRecordMessage.AddedSuccessfully);
        }
        
        private async Task<OdometerRecord> AddOdometerRecord(OdometerRecordAddRequest request)
        {
            OdometerRecord odometerRecord = await _context.ExecuteTransactionAsync(async () =>
            {
                OdometerRecord newOdometerRecord = _mapper.Map<OdometerRecord>(request);
                
                newOdometerRecord = (await _context.OdometerRecords.AddAsync(newOdometerRecord)).Entity;
                var user = await _userService.GetCurrentUserInfo();
                if (user.Item1)
                {
                    newOdometerRecord.UserId = user.Item2.Id;
                    newOdometerRecord.UserName = user.Item2.Name;
                    newOdometerRecord.UserType = user.Item2.Role.GetDisplayName();
                }
                await _context.SaveChangesAsync();

                return newOdometerRecord;
            });
            return odometerRecord;
        }
    }
}