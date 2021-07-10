using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Delete
{
    public class AppSettingDeleteHandler : ApiRequestHandler<AppSettingDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public AppSettingDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AppSettingDeleteRequest request)
        {
            AppSetting appSetting = await _context.AppSettings
                .FindAsync(request.AppSettingsId);

            if (appSetting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            /*_context.AppSettings.Remove(appSetting);
            await _context.SaveChangesAsync();*/
            
            return ActionResult.Ok(ApiMessages.AppSettingMessage.DeletedSuccessfully);
        }
    }
}
