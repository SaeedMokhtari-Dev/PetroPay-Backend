using System;
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

        public EmailService(IOptions<SmtpOptions> smtpOptions, IConfiguration configuration)
        {
            this._configuration = configuration;
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
        public async Task SendResetPasswordEmail(string email, string fullName, Guid token)
        {
            var clientBaseUrl = _configuration.GetValue<string>("ClientBaseUrl");
            string htmlBody = $"<a href='{clientBaseUrl}/auth/password/change/{token}'>click here to reset password</a>";
            await SendMail(email, "Reset Password", htmlBody, $"{fullName}");
        }
        /*public async Task SendUserActivationEmail(ApiMessages.User user)
        {
            var clientBaseUrl = _configuration.GetValue<string>("ClientBaseUrl");
            string htmlBody = $"<a href='{clientBaseUrl}/auth/change-password/{user.PasswordResetToken.Token}'>click here to activate</a>";
            await SendMail(user.Email, "Activate Account", htmlBody, $"{user.FirstName} {user.LastName}");
        }*/
    }
}
