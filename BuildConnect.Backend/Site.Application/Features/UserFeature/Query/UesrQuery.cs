using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Query;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
}
