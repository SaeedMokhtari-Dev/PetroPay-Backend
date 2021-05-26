using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Reports.PetrolStationLists.Get
{
    public class PetrolStationListGetHandler : ApiRequestHandler<PetrolStationListGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public PetrolStationListGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetrolStationListGetRequest request)
        {
            if(_userContext.Role != RoleType.Admin)
                return ActionResult.Error(ApiMessages.Forbidden);
            
            var query = _context.ViewPetrolStationLists.OrderByDescending(w => w.StationName)
                .AsQueryable();
            
            query = createQuery(query, request);
            
            PetrolStationListGetResponse response = new PetrolStationListGetResponse();
            response.TotalCount = await query.CountAsync();

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetrolStationListGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }

        private IQueryable<ViewPetrolStationList> createQuery(IQueryable<ViewPetrolStationList> query, PetrolStationListGetRequest request)
        {
            if (!string.IsNullOrEmpty(request.Region))
            {
                query = query.Where(w => w.StationLucationName.Contains(request.Region));
            }
            return query;

        }
    }
}
