using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.PermissionFeatures.Query;

public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, PermissionDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PermissionDto> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Permissions.FindAsync(request.Id);

        if (role == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }

        return _mapper.Map<PermissionDto>(role);
    }
}