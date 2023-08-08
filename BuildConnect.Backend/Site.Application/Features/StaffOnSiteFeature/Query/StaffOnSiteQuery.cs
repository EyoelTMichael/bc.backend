using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.StaffOnSiteFeature.Query;

public class GetStaffOnSiteQuery : IRequest<StaffOnSiteDto>
{
    public Guid Id { get; set; }
}

public class GetAllStaffOnSitesQuery : IRequest<IEnumerable<StaffOnSiteDto>>
{
}