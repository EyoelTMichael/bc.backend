using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.TaskFeatures.Command;

public class CreateTaskCommand : IRequest<Guid>
{
    public string TaskDescription { get; set; }
    public Guid AssigneeUserId { get; set; }
    public Guid AssignedUserId { get; set; }
}

public class UpdateTaskCommand : IRequest<TaskModelDto>
{
    public Guid Id { get; set; }
    public string TaskDescription { get; set; }
    public Guid AssigneeUser { get; set; }
    public Guid AssignedUser { get; set; }
}

public class DeleteTaskCommand : IRequest
{
    public Guid Id { get; set; }
}
