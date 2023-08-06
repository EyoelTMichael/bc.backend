using MediatR;
using Microsoft.AspNetCore.Http;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Command;

public class RegisterUserCommand : IRequest<Guid>
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public IFormFile ProfileImage { get; set; }
    public Guid RoleId { get; set; }
}

public class UpdateUserCommand : IRequest<UserDto>
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public IFormFile? ProfileImage { get; set; }
}


public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}