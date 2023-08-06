using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.RoleFeatures.Command;

public class AssignPermissionsToRoleCommandHandler : IRequestHandler<AssignPermissionsToRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public AssignPermissionsToRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AssignPermissionsToRoleCommand request, CancellationToken cancellationToken)
    {
        // ensure role exists
        var roleExists = await _context.Roles.AnyAsync(r => r.Id == request.RoleId);
        if (!roleExists)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        foreach (var permissionId in request.PermissionIds.Distinct())
        {
            // ensure permission exists
            var permissionExists = await _context.Permissions.AnyAsync(p => p.Id == permissionId);
            if (!permissionExists)
            {
                throw new NotFoundException(nameof(Permission), permissionId);
            }

            // check if the RolePermission association already exists
            var rolePermissionExists = await _context.RolePermissions
                .AnyAsync(rp => rp.RoleId == request.RoleId && rp.PermissionId == permissionId);

            if (!rolePermissionExists)
            {
                // add new association
                var rolePermission = new RolePermission
                {
                    PermissionId = permissionId,
                    RoleId = request.RoleId
                };

                _context.RolePermissions.Add(rolePermission);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}