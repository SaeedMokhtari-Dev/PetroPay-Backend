using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetHandler : ApiRequestHandler<MenuGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public MenuGetHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(MenuGetRequest request)
        {
            var query = _context.Menus
                .Include(w => w.Parent)
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            query = createQuery(query, request);
            MenuGetResponse response = new MenuGetResponse();
            response.TotalCount = await query.CountAsync();

            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            
            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<MenuGetResponseItem>>(result);
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<Menu> createQuery(IQueryable<Menu> query, MenuGetRequest request)
        {
            /*if (request.CompanyId.HasValue)
            {
                query = query.Where(w => w.CompanyBarnch.CompanyId == request.CompanyId.Value);
            }
            if (request.CompanyBranchId.HasValue)
            {
                query = query.Where(w => w.CompanyBarnchId == request.CompanyBranchId.Value);
            }
            if (request.NeedActivation)
            {
                query = query.Where(w => string.IsNullOrEmpty(w.MenuNfcCode.Trim()) || w.MenuNfcCode.Trim() == "0");
            }*/
            return query;

        }
    }
}
