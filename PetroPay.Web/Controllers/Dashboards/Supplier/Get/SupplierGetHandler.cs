using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Dashboards.Supplier.Get
{
    public class SupplierGetHandler : ApiRequestHandler<SupplierGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public SupplierGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(SupplierGetRequest request)
        {
            if(_userContext.Role != RoleType.Supplier)
                return ActionResult.Error(ApiMessages.Forbidden);

            var station = await _context.PetroStations.SingleOrDefaultAsync(w => w.StationId == request.SupplierId);
            
            if(station == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            SupplierGetResponse response = new SupplierGetResponse();
            response.StationBalance = station.StationBalance ?? 0;
            response.StationBonusBalance = station.StationBonusBalance ?? 0;
            
            return ActionResult.Ok(response);
        }
    }
}
