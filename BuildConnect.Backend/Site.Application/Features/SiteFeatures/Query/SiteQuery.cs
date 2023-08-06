using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetSiteQuery : IRequest<SiteDto>
{
    public Guid Id { get; set; }
}
