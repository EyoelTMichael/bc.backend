using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.TaskFeatures.Command;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskModel
        {
            TaskDescription = request.TaskDescription,
            AssigneeUserId = request.AssigneeUserId,
            AssignedUserId = request.AssignedUserId
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);
        return task.Id;
    }
}