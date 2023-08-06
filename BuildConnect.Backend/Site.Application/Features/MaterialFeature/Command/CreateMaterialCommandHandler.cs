using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.PermissionFeatures.Command;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.MaterialFeature.Command;

public class CreatePermissionCommandHandler : IRequestHandler<CreateMaterialCommand, MaterialDto>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePermissionCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MaterialDto> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = new Material
        {
            Name = request.Name,
            UnitOfMeasure = request.UnitOfMeasure
        };

        _context.Materials.Add(material);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MaterialDto>(material);
    }
}
