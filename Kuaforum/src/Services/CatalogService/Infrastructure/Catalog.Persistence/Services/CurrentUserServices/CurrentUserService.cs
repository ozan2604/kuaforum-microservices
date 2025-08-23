using Catalog.Application.Services.CurrentUserServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Services.CurrentUserServices
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

                // Tercih sırası: nameidentifier → sub
                var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? user.FindFirst("sub")?.Value;

                if (Guid.TryParse(id, out var g)) return g;

                return null;
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

        public string? Email
            => _http.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value
            ?? _http.HttpContext?.User?.FindFirst("email")?.Value;
    }
}
