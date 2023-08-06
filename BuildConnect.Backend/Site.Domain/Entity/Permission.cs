using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class Permission: BaseModel
    {
        public string Name { get; set; }
    }
    public class PermissionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
