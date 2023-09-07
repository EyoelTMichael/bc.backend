using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialFeatures.Query;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetAllSitesQueryHandler : IRequestHandler<GetAllSitesQuery, IEnumerable<SiteDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSitesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SiteDTO>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
    {
        var sites = await _context.Sites.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<SiteDTO>>(sites);
    }
}

