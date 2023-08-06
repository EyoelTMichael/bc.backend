using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.PermissionFeatures.Query;

public class GetPermissionQuery : IRequest<PermissionDto>
{
    public Guid Id { get; set; }
}

public class GetAllPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
{
}