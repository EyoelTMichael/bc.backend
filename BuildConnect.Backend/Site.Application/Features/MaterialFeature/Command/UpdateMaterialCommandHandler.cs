using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.PermissionFeatures.Command;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;
using Site.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.MaterialFeature.Command;

public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, MaterialDto>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMaterialCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MaterialDto> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materials.FindAsync(request.Id);

        if (material == null)
        {
            throw new NotFoundException(nameof(Material), "Material Not found");
        }

        material.Name = request.Name ?? material.Name;
        material.UnitOfMeasure = request.UnitOfMeasure ?? material.UnitOfMeasure;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MaterialDto>(material);
    }
}
