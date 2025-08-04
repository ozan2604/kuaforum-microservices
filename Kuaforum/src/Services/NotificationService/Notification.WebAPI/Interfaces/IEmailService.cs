namespace Notification.WebAPI.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml = true);
        Task SendEmailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    }
}
