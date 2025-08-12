using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class StaffSkill : BaseEntity
    {
        public Guid StaffId; 
        public Staff Staff = null!;
        public string SkillName = null!; 

    public ICollection<StaffSkill> Skills { get; set; } = new List<StaffSkill>();
        public StaffSkill()
        {
        }
        public StaffSkill(Guid staffId, string skillName)
        {
            StaffId = staffId;
            SkillName = skillName;
        }

    }
}
