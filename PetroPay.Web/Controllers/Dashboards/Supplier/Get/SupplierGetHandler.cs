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
            if(_userContext.Role != RoleType.Supplier && _userContext.Role != RoleType.SupplierBranch)
                return ActionResult.Error(ApiMessages.Forbidden);

            if (_userContext.Role == RoleType.Supplier && !request.SupplierId.HasValue)
                request.SupplierId = _userContext.Id;

            if (_userContext.Role == RoleType.SupplierBranch && !request.SupplierBranchId.HasValue)
                request.SupplierBranchId = _userContext.Id;
            
            SupplierGetResponse response = new SupplierGetResponse();
            if (request.SupplierId.HasValue)
            {
                var company =
                    await _context.PetrolCompanies.Include(w => w.PetroStations).SingleOrDefaultAsync(w => w.PetrolCompanyId == request.SupplierId);
                if(company == null)
                    return ActionResult.Error(ApiMessages.ResourceNotFound);

                response.StationBalance = company.PetrolCompanyBalnce ?? 0;

                response.PetroStationItems = company.PetroStations.Select(w => new PetroStationItem()
                {
                    StationName = w.StationName,
                    StationUserName = w.StationUserName,
                    StationBalance = w.StationBalance ?? 0,
                    StationBonusBalance = w.StationBonusBalance ?? 0
                }).ToList();
            }
            else
            {
                var petroStation = await _context.PetroStations.Include(w => w.StationUsers)
                    .SingleOrDefaultAsync(w => w.StationId == request.SupplierBranchId.Value);
                if(petroStation == null)
                    return ActionResult.Error(ApiMessages.ResourceNotFound);

                response.StationBalance = petroStation.StationBalance;
                response.StationBonusBalance = petroStation.StationBonusBalance;

                response.PetroStationItems = petroStation.StationUsers.Select(w => new PetroStationItem()
                {
                    StationName = w.StationWorkerFname,
                    StationUserName = w.StationUserName,
                    StationBalance = w.WorkerBonusBalance ?? 0,
                    StationBonusBalance = w.WorkerBonusBalance ?? 0
                }).ToList();
            }
            
            
            return ActionResult.Ok(response);
        }
    }
}
