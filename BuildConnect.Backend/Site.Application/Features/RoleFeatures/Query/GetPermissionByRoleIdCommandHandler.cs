using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Site.Application.Features.RoleFeatures.Query;

public class GetPermissionsByRoleIdQueryHandler : IRequestHandler<GetPermissionsByRoleIdQuery, List<PermissionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPermissionsByRoleIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PermissionDto>> Handle(GetPermissionsByRoleIdQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _context.RolePermissions
            .Where(rp => rp.RoleId == request.RoleId)
            .Select(rp => rp.Permission)
            .ToListAsync(cancellationToken);

        // Use a mapper to convert Permissions to PermissionDtos
        // Assume we have a IMapper _mapper
        // return _mapper.Map<List<PermissionDto>>(permissions);

        // If no mapper, create the DTO manually
        var permissionDtos = permissions.Select(p => new PermissionDto
        {
            Id = p.Id,
            Name = p.Name
            // Map other fields...
        }).ToList();

        return permissionDtos;
    }
}
