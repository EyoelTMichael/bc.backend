using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.PermissionFeatures.Command;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePermissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = new Permission
        {
            Name = request.Name
        };

        _context.Permissions.Add(permission);

        await _context.SaveChangesAsync(cancellationToken);

        return permission.Id;
    }
}