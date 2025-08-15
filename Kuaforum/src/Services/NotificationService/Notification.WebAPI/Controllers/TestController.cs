using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.WebAPI.Interfaces;
using MassTransit;
using KuaforumShared;

namespace Notification.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IPublishEndpoint _publishEndpoint;

        public TestController(IEmailService emailService, IPublishEndpoint publishEndpoint)
        {
            _emailService = emailService;
            _publishEndpoint = publishEndpoint;
        }

        [Authorize]
        [HttpGet("test-mail")]
        public async Task<IActionResult> SendTestMail()
        {
            var username = User.Identity?.Name;
            try
            {
                await _emailService.SendEmailAsync(
                    new[] { "orhangolcur0@gmail.com" },
                    "Deneme Maili",
                    "Selam! Bu mail NotificationService üzerinden geldi.");

                await _publishEndpoint.Publish(new LogMessage
                {
                    UserName = username,
                    ServiceName = "notification",
                    ActionName = "SendTestMail",
                    Level = "Information",
                    Message = "Mail sent successfully",
                    TimeStamp = DateTime.UtcNow
                });

                return Ok("✅ Mail gönderildi.");
            }
            catch (Exception ex)
            {
                await _publishEndpoint.Publish(new LogMessage
                {
                    UserName = username,
                    ServiceName = "notification",
                    ActionName = "SendTestMail",
                    Level = "Error",
                    Message = $"Mail sending failed: {ex.Message}",
                    TimeStamp = DateTime.UtcNow
                });

                return BadRequest($"❌ Hata: {ex.Message}");
            }
        }
    }
}
