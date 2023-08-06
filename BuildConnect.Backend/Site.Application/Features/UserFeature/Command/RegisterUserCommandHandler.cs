using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using Microsoft.AspNet.Identity;

namespace Site.Application.Features.UserFeature.Command;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public RegisterUserCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        string profileImageFileName = null;
        if (request.ProfileImage != null)
        {
            profileImageFileName = await _fileService.SaveFileAsync(request.ProfileImage, "Content");
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);


        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
            PasswordHash = passwordHash,
            ProfileImage = profileImageFileName,
            RoleId = request.RoleId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}