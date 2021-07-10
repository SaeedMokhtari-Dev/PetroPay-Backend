using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Add
{
    public class AppSettingAddHandler : ApiRequestHandler<AppSettingAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public AppSettingAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AppSettingAddRequest request)
        {
            await AddAppSetting(request);
            
            return ActionResult.Ok(ApiMessages.AppSettingMessage.AddedSuccessfully);
        }
        
        private async Task AddAppSetting(AppSettingAddRequest request)
        {
            AppSetting newAppSetting = _mapper.Map<AppSetting>(request);
            _context.AppSettings.Add(newAppSetting);
            await _context.SaveChangesAsync();
        }
    }
}