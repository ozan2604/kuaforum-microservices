using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreateAt { get; set; } = DateTime.UtcNow;
        public Guid? CreateUserId { get; set; } = default!;
        public string CreateUserName { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }
        public Guid? UpdateUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeleteAt { get; set; }
        public Guid? DeleteUserId { get; set; }
    }
}
