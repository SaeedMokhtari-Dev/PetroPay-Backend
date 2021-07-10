using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.AppSettings.Detail
{
    public class AppSettingDetailHandler : ApiRequestHandler<AppSettingDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public AppSettingDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(AppSettingDetailRequest request)
        {
            AppSetting appSetting = await _context.AppSettings
                .FirstOrDefaultAsync();
            
            if (appSetting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            AppSettingDetailResponse response = _mapper.Map<AppSettingDetailResponse>(appSetting);
            
            return ActionResult.Ok(response);
        }
    }
}
