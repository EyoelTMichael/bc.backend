using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class TaskModel : BaseModel
    {
        public string TaskDescription { get; set; } = string.Empty;
        public Guid AssigneeUserId { get; set; }
        public Guid AssignedUserId { get; set; }

        public User AssigneeUser { get; set; }
        public User AssignedUser { get; set; }
    }

    public class TaskModelDto
    {
        public Guid Id { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        public User AssigneeUser { get; set; }
        public User AssignedUser { get; set; }
    }
}
