using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.WebAPI.Interfaces;
using MassTransit;
using KuaforumShared;

namespace Notification.WebAPI.Controllers
{
    [Route("notification/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Authorize]
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");

        [Authorize]
        [HttpGet("publish-only")]
        public async Task<IActionResult> PublishOnly([FromServices] IPublishEndpoint pub)
        {
            await pub.Publish(new LogMessage
            {
                UserName = User.Identity?.Name,
                ServiceName = "notification",
                ActionName = "PublishOnly",
                Level = "Information",
                Message = "Just publish",
                TimeStamp = DateTime.UtcNow
            });
            return Ok("published");
        }

        [Authorize]
        [HttpGet("test-mail")]
        public async Task<IActionResult> SendTestMail()
        {
            try
            {
                await _emailService.SendEmailAsync(
                    new[] { "coderozan26@gmail.com" },
                    "Deneme Maili",
                    "Selam! Bu mail NotificationService üzerinden geldi.");

                return Ok("✅ Mail gönderildi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"❌ Hata: {ex.Message}");
            }
        }
    }
}
