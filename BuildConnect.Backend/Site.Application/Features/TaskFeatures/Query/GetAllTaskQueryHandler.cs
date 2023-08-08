using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.TaskFeatures.Query;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskModelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTasksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TaskModelDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasksWithUsers = _context.Tasks
    .Include(t => t.AssigneeUser)
    .Include(t => t.AssignedUser)
    .ToList();

        return _mapper.Map<IEnumerable<TaskModelDto>>(tasksWithUsers);
    }
}
