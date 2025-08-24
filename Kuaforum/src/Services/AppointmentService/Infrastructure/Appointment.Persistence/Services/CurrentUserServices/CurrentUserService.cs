using Appointment.Application.Services.CurrentUserServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Appointment.Persistence.Services.CurrentUserServices
{
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _http;

        public CurrentUserService(IHttpContextAccessor http)
        {
            _http = http;
        }

        public bool IsAuthenticated => _http.HttpContext?.User?.Identity?.IsAuthenticated == true;

        public Guid? UserId
        {
            get
            {
                var user = _http.HttpContext?.User;
                if (user == null) return null;

                var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? user.FindFirst("sub")?.Value
                      ?? user.FindFirst("user_id")?.Value
                      ?? user.FindFirst("userId")?.Value
                      ?? user.FindFirst("uid")?.Value
                      ?? user.FindFirst("id")?.Value;

                return Guid.TryParse(id, out var g) ? g : null;
            }
        }

        public string? UserName
        {
            get
            {
                var user = _http.HttpContext?.User;
                if (user == null) return null;

                return user.FindFirst("preferred_username")?.Value
                    ?? user.FindFirst("unique_name")?.Value
                    ?? user.FindFirst(ClaimTypes.Name)?.Value
                    ?? user.FindFirst("name")?.Value
                    ?? user.FindFirst(ClaimTypes.Email)?.Value
                    ?? user.FindFirst("email")?.Value;
            }
        }

        public string? Email => _http.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value
            ?? _http.HttpContext?.User?.FindFirst("email")?.Value;
    }
}
