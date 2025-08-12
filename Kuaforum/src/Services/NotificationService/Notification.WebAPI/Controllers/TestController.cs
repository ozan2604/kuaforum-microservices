using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.WebAPI.Interfaces;

namespace Notification.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("test-mail")]
        public async Task<IActionResult> SendTestMail()
        {
            try
            {
                await _emailService.SendEmailAsync(
                    new[] { "orhangolcur0@gmail.com" },
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
