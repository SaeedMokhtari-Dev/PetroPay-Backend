using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Edit
{
    public class AppSettingEditHandler : ApiRequestHandler<AppSettingEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public AppSettingEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AppSettingEditRequest request)
        {
            AppSetting editAppSetting = await _context.AppSettings
                .FirstOrDefaultAsync();

            if (editAppSetting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditAuditingAppSettingAppSettingAppSetting(editAppSetting, request);
            return ActionResult.Ok(ApiMessages.AppSettingMessage.EditedSuccessfully);
        }

        private async Task EditAuditingAppSettingAppSettingAppSetting(AppSetting editAppSetting, AppSettingEditRequest request)
        {
            _mapper.Map(request, editAppSetting);
            await _context.SaveChangesAsync();
        }
    }
}