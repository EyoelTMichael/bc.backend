using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.UserFeature.Query;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public LoginUserQueryHandler(IApplicationDbContext context, IMapper mapper, IJwtService jwtService)
    {
        _context = context;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await _context.Users.Where(u => u.UserName == request.UserName).FirstOrDefaultAsync();
        if (foundUser == null)
        {
            throw new NotFoundException(nameof(User), "user not found");
        }
        bool valid = BCrypt.Net.BCrypt.Verify(request.Password, foundUser.PasswordHash);
        if (valid)
        {
            return _jwtService.GenerateToken(foundUser);
        }
        throw new Exception("Bad Request");
    }
}
