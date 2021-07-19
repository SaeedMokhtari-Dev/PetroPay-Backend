using System;
using System.Data;
using System.IO;
using FastReport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PetroPay.Core.Interfaces;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Services
{
    public class ReportService: ITransient
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        
        public ReportService(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public Stream GetInvoicePdf(int invoiceNumber)
        {
            var connectionString = _configuration.GetValue<string>(SettingsKeys.ConnectionString);
            
            Report rep = new Report();

            rep.Load(_hostingEnvironment.ContentRootPath + "/Report/Invoice.frx");

            var dataset1 = new DataSet("Connection");
            //var invoice = await _context.ViewInvoices.FirstOrDefaultAsync(w => w.InvoiceNumber == 202100003);
            SqlConnection con = null;
            try {
                
                //create connection object
                con = new SqlConnection(connectionString);
                //create query string(SELECT QUERY)
                String query=$"SELECT * FROM View_Invoice WHERE InvoiceNumber = {invoiceNumber}";
                con.Open();
                //Adapter bind to query and connection object
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                
                //fill the dataset
                adapter.Fill(dataset1, "View_Invoice");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                con.Close();                  
            }
            
            rep.RegisterData(dataset1);

            if (rep.Report.Prepare())
            {
                // Set PDF export props
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport =
                    new FastReport.Export.PdfSimple.PDFSimpleExport();
                
                MemoryStream strm = new MemoryStream();
                rep.Report.Export(pdfExport, strm);
                rep.Dispose();
                pdfExport.Dispose();
                strm.Position = 0;

                // return stream in browser
                return strm;
            }
            else
            {
                return null;
            } 
        }
    }
}