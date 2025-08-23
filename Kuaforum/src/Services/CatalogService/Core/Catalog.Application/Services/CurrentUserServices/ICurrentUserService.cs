using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.CurrentUserServices
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        Guid? UserId { get; }          // sub veya nameidentifier (GUID ise)
        string? UserName { get; }      // preferred_username / unique_name / name / email
        string? Email { get; }
    }
}
