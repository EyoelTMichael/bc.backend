using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command;
public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateSiteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
    {
        var site = new SiteModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Owner = request.Owner,
            Longitude = request.Longitude,
            Latitude = request.Latitude,
        };

        await _context.Sites.AddAsync(site, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return site.Id;
    }
}
