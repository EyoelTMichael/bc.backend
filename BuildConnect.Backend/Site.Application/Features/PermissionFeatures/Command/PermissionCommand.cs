using MediatR;

namespace Site.Application.Features.PermissionFeatures.Command;

public class CreatePermissionCommand : IRequest<Guid>
{
    public string Name { get; set; }
}
