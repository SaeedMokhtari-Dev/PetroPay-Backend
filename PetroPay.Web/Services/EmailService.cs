using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Interfaces;
using PetroPay.Web.Configuration.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace PetroPay.Web.Services
{
    public class EmailService: ITransient
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly IConfiguration _configuration;
        private readonly ReportService _reportService;

        public EmailService(IOptions<SmtpOptions> smtpOptions, IConfiguration configuration, ReportService reportService)
        {
            this._configuration = configuration;
            _reportService = reportService;
            this._smtpOptions = smtpOptions.Value;
        }

        public async Task SendMail(string receiverEmail, string subject, string htmlBody, string name)
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();
            
            // from
            message.From.Add(new MailboxAddress(_smtpOptions.FromName, _smtpOptions.FromAddress));
            // to
            message.To.Add(new MailboxAddress(name, receiverEmail));
            
            message.Subject = subject;
            bodyBuilder.HtmlBody = htmlBody;
            message.Body = bodyBuilder.ToMessageBody();
             

            var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };

            await client.ConnectAsync(_smtpOptions.Hostname, _smtpOptions.Port, _smtpOptions.GetSecureSocketOption());
            await client.AuthenticateAsync(_smtpOptions.Username, _smtpOptions.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        public async Task SendMailWithAttachment(string receiverEmail, string subject, string htmlBody, string name,
            byte[] data)
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();
            
            // from
            message.From.Add(new MailboxAddress(_smtpOptions.FromName, _smtpOptions.FromAddress));
            // to
            message.To.Add(new MailboxAddress(name, receiverEmail));
            
            message.Subject = subject;
            bodyBuilder.HtmlBody = htmlBody;
            bodyBuilder.Attachments.Add("Invoice", data, new ContentType("application", "pdf"));
            message.Body = bodyBuilder.ToMessageBody();
            

            var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };

            await client.ConnectAsync(_smtpOptions.Hostname, _smtpOptions.Port, _smtpOptions.GetSecureSocketOption());
            await client.AuthenticateAsync(_smtpOptions.Username, _smtpOptions.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        public async Task SendResetPasswordEmail(string email, string fullName, Guid token)
        {
            var clientBaseUrl = _configuration.GetValue<string>("ClientBaseUrl");
            string htmlBody = $"<a href='{clientBaseUrl}/auth/password/change/{token}'>click here to reset password</a>";
            await SendMail(email, "Reset Password", htmlBody, $"{fullName}");
        }

        public async Task SendSubscriptionInvoiceMail(string receiverEmail, string name, string invoiceNumber)
        {
            var clientBaseUrl = _configuration.GetValue<string>("ClientBaseUrl");
            string htmlBody = "<p>Your Subscription Confirmed Successfully</p>" +
                              "<p>For see and download subscription invoice click on the link below.</p>" +
                              $"<a href='{clientBaseUrl}/app/subscription/invoice/{invoiceNumber}'>click here to open the page</a>";
            string subject = "Your Subscription Confirmed Successfully";

            Stream stream = await _reportService.GetInvoicePdf(int.Parse(invoiceNumber));
            
            await SendMailWithAttachment(receiverEmail, subject, htmlBody, name, ReadFully(stream));
        }
        private byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
