using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialFeatures.Query;
using Site.Domain.Entity;


namespace Site.Application.Features.MaterialFeature.Query;

public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, IEnumerable<MaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMaterialsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MaterialDto>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
    {
        var materials = await _context.Materials.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<MaterialDto>>(materials);
    }
}
