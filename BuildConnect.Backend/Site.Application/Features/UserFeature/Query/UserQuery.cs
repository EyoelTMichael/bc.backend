using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Query;

public class GetUserByIdQuery : IRequest<UserDTO>
{
    public Guid Id { get; set; }
}

public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
{
}

public class GetAllRolesQuery : IRequest<IEnumerable<string>>
{
}