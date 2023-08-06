using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command;

public record CreateSiteCommand(string Name, string Owner, long Longitude, long Latitude) : IRequest<Guid>;
public class UpdateSiteCommand : IRequest<SiteDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public long Longitude { get; set; }
    public long Latitude { get; set; }
}
public class DeleteSiteCommand : IRequest
{
    public Guid Id { get; set; }
}