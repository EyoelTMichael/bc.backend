using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetSitesByUserQueryHandler : IRequestHandler<GetSiteByUserQuery, IEnumerable<SiteDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSitesByUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SiteDTO>> Handle(GetSiteByUserQuery request, CancellationToken cancellationToken)
    {
        var sites = await _context.SiteUsers
            .Where(su => su.UserId == request.UserId)
            .Select(su => su.Site)
            .ToListAsync(cancellationToken);

        // Assuming you have a mapper to map from SiteModel to SiteDto.
        return sites.Select(site => _mapper.Map<SiteDTO>(site));
    }

}