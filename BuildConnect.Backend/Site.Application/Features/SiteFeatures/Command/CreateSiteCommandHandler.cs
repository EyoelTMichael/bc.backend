﻿using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreatedAt = DateTime.UtcNow
        };

        await _context.Sites.AddAsync(site, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return site.Id;
    }
}