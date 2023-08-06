using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class Role: BaseModel
    {
        public string Name { get; set; }
    }

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    }
}
