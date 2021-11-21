using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Get
{
    public class NewCustomerGetHandler : ApiRequestHandler<NewCustomerGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public NewCustomerGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerGetRequest request)
        {
            var query = _context.NewCustomers.OrderByDescending(w => w.CustReqId)
                .AsQueryable();

            query = createQuery(query, request);
            
            NewCustomerGetResponse response = new NewCustomerGetResponse();
            response.TotalCount = await query.CountAsync();
            
            if(!request.ExportToFile)
                query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<NewCustomerGetResponseItem>>(result);

            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
        private IQueryable<NewCustomer> createQuery(IQueryable<NewCustomer> query, NewCustomerGetRequest request)
        {
            if (!string.IsNullOrEmpty(request.DateFrom))
            {
                DateTime dateTimeFrom = DateTime.ParseExact(request.DateFrom, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture);
                query = query.Where(w => w.CutReqDatetime.HasValue && w.CutReqDatetime.Value >= dateTimeFrom);
            }
            if (!string.IsNullOrEmpty(request.DateTo))
            {
                DateTime dateTimeTo = DateTime.ParseExact(request.DateTo, DateTimeConstants.DateFormat,
                    CultureInfo.InvariantCulture).AddDays(1);
                query = query.Where(w => w.CutReqDatetime.HasValue && w.CutReqDatetime.Value <= dateTimeTo);
            }
            if (request.Status.HasValue)
            {
                switch (request.Status.Value)
                {
                    case 1: //Confirmed
                        query = query.Where(w => w.CustReqStatus.HasValue && w.CustReqStatus == true);
                        break;
                    case 2: //NotConfirmed
                        query = query.Where(w => w.CustReqStatus == null || w.CustReqStatus == false);
                        break;
                }
            }
            return query;

        }
    }
}
