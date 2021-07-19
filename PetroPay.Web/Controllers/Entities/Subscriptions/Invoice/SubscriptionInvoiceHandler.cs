using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Invoice
{
    public class SubscriptionInvoiceHandler : ApiRequestHandler<SubscriptionInvoiceRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionInvoiceHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionInvoiceRequest request)
        {
            Subscription subscription = await _context.Subscriptions.Include(w => w.Company)
                .FirstOrDefaultAsync(w => w.SubscriptionInvoiceNumber.HasValue && w.SubscriptionInvoiceNumber.Value == request.SubscriptionInvoiceId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            var appSetting = await _context.AppSettings.FirstOrDefaultAsync();
            
            if(appSetting == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            SubscriptionInvoiceResponse response = new SubscriptionInvoiceResponse();
            response.InvoiceNumber = subscription.SubscriptionInvoiceNumber ?? 0;
            response.DateOfIssue = subscription.SubscriptionDate.HasValue
                ? subscription.SubscriptionDate.Value.ToString(DateTimeConstants.DateFormat) : DateTime.Now.ToString(DateTimeConstants.DateFormat);

            response.CompanyLogo = $"data:image/png;base64,{appSetting.CompanyLogo}";
            response.CompanyNameAr = appSetting.CompanyNameAr;
            response.CompanyNameEn = appSetting.CompanyNameEn;
            response.CompanyAddress = appSetting.CompanyAddress;
            response.CompanyTaxRecordNumber = appSetting.ComapnyTaxRecordNumber;
            response.CompanyCommercialRecordNumber = appSetting.CompanyCommercialRecordNumber;
            response.CompanyEmail = appSetting.CompanyEmail;
            response.CompanyWebsite = appSetting.ComapnyWebsite;

            response.CustomerName = subscription.CompanyId.HasValue ? subscription.Company.CompanyName : String.Empty;
            response.CustomerAddress = subscription.CompanyId.HasValue ? subscription.Company.CompanyAddress : String.Empty;

            response.UnitCost = (subscription.SubscriptionCost ?? 0) + (subscription.SubscriptionDiscountValues ?? 0) -
                                (subscription.SubscriptionTaxValue ?? 0) - (subscription.SubscriptionVatTaxValue ?? 0);
            response.Quantity = 1;
            response.Amount = response.UnitCost;
            response.ServiceStartDate = subscription.SubscriptionStartDate.HasValue
                ? subscription.SubscriptionStartDate.Value.ToString(DateTimeConstants.DateFormat) : "";
            response.ServiceEndDate = subscription.SubscriptionEndDate.HasValue
                ? subscription.SubscriptionEndDate.Value.ToString(DateTimeConstants.DateFormat) : "";

            response.SubTotal = response.UnitCost;
            response.Discount = subscription.SubscriptionDiscountValues ?? 0;
            response.TaxRate = appSetting.ComapnyTaxRate ?? 0;
            response.Tax = subscription.SubscriptionTaxValue ?? 0;
            response.VatRate = appSetting.CompanyVatRate ?? 0;
            response.Vat = subscription.SubscriptionVatTaxValue ?? 0;
            response.Total = subscription.SubscriptionCost ?? 0;
            
            return ActionResult.Ok(response);
        }
    }
}
