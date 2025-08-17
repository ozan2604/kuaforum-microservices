using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.WebAPI.Interfaces;
using MassTransit;
using KuaforumShared;
using System.Security.Claims;

namespace Notification.WebAPI.Controllers
{
    [Route("notification/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _email;
        private readonly IPublishEndpoint _bus;
        private readonly IConfiguration _cfg;

        public TestController(IEmailService email, IPublishEndpoint bus, IConfiguration cfg)
        {
            _email = email; _bus = bus; _cfg = cfg;
        }

        [Authorize]
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");


        [Authorize]
        [HttpGet("test-mail")]
        public async Task<IActionResult> SendTestMail()
        {
            var to = new[] { "coderozan26@gmail.com" };
            var subject = "Deneme Maili";
            var body = "Selam! Bu mail NotificationService üzerinden geldi.";

            var userName =
            User?.Identity?.IsAuthenticated == true
                ? (User.FindFirst(ClaimTypes.Name)?.Value
            ?? User.FindFirst("preferred_username")?.Value
            ?? User.FindFirst("name")?.Value
            ?? User.FindFirst("unique_name")?.Value
            ?? User.FindFirst(ClaimTypes.Email)?.Value
            ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst("sub")?.Value)
        : null;

            var serviceName = _cfg["Service:Name"] ?? "notification";
            var actionName = $"{Request?.Method} {Request?.Path}";


            try
            {
                await _email.SendEmailAsync(to, subject, body);

                await _bus.Publish(new LogMessage
                {
                    UserName = userName,
                    ServiceName = serviceName,
                    ActionName = actionName,
                    Level = "Information",
                    Message = "Mail sent successfully",
                    TimeStamp = DateTime.UtcNow,
                });

                return Ok("Mail gönderildi.");
            }
            catch (Exception ex)
            {
                await _bus.Publish(new LogMessage
                {
                    
                    UserName = userName,
                    ServiceName = serviceName,
                    ActionName = actionName,
                    Level = "Error",
                    Message = $"Mail sending failed: {ex.Message}",
                    TimeStamp = DateTime.UtcNow,
                });

                return BadRequest("Mail gönderilemedi.");
            }
        }
    }
}
