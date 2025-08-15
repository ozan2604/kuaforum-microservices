using MassTransit;
using KuaforumShared;
using Microsoft.AspNetCore.Http;
using Notification.WebAPI.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Notification.WebAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService(IConfiguration configuration, IPublishEndpoint publishEndpoint, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _publishEndpoint = publishEndpoint;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendEmailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendEmailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            try
            {
                MailMessage mail = new();
                mail.IsBodyHtml = isBodyHtml;
                foreach (var to in tos)
                    mail.To.Add(to);

                mail.Subject = subject;
                mail.Body = body;
                mail.From = new MailAddress(_configuration["Mail:Username"], "Kuaforüm", System.Text.Encoding.UTF8);

                SmtpClient smtp = new();
                smtp.Timeout = 10000; // 10 seconds timeout
                smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                smtp.Host = _configuration["Mail:Host"];
                smtp.Port = Convert.ToInt32(_configuration["Mail:Port"]);
                smtp.EnableSsl = Convert.ToBoolean(_configuration["Mail:EnableSsl"]);
                await smtp.SendMailAsync(mail);

                var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                await _publishEndpoint.Publish(new LogMessage
                {
                    UserName = username,
                    ServiceName = "notification",
                    ActionName = "SendEmail",
                    Level = "Information",
                    Message = $"Mail sent to {string.Join(",", tos)}",
                    TimeStamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                await _publishEndpoint.Publish(new LogMessage
                {
                    UserName = username,
                    ServiceName = "notification",
                    ActionName = "SendEmail",
                    Level = "Error",
                    Message = $"Mail sending failed: {ex.Message}",
                    TimeStamp = DateTime.UtcNow
                });

                throw;
            }
        }
    }
}

