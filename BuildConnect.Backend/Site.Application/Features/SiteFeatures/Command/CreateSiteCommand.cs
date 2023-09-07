using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command;

//public record CreateSiteCommand(string Name, string Owner, long Longitude, long Latitude) : IRequest<Guid>;
public class CreateSiteCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Owner { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}
public class UpdateSiteCommand : IRequest<SiteDTO>
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