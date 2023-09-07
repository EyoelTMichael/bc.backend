using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.WorkItemFeature.Query;

public class GetAllWorkItemsByScheduleQuery : IRequest<IEnumerable<WorkItemDTO>>
{
    public Guid ScheduleId { get; set; }
}
