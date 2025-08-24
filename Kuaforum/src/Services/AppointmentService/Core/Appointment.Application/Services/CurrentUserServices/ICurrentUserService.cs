using System;

namespace Appointment.Application.Services.CurrentUserServices
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        Guid? UserId { get; }
        string? UserName { get; }
        string? Email { get; }
    }
}
