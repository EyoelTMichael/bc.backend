using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Query;

public class GetManPowerCostByWorkItemQuery : IRequest<IEnumerable<ManPowerCostDTO>>
{
    public Guid WorkItem { get; set; }
}
