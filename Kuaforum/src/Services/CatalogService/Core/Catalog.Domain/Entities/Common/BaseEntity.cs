using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } 
        public Guid? CreateUserId { get; set; } = default!;
        public string CreateUserName {  get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdateUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeleteUserId { get; set; }

    }
}
