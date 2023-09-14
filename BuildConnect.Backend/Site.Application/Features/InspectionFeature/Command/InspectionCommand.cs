using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.InspectionFeature.Command;

public class CreateInspectionCommand : IRequest<Guid>
{
    public string Description { get; set; }
    public Guid ScheduleId { get; set; }
    public Guid AssignedUserId { get; set; }
    public Guid CreatedById { get; set; }
}

public class UpdateInspectionCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public InspectionStatus? Status { get; set; }
}

public class DeleteInspectionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}