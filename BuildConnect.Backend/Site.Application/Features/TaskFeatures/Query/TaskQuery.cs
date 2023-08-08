using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.TaskFeatures.Query;

public class GetTaskQuery : IRequest<TaskModelDto>
{
    public Guid Id { get; set; }
}

public class GetAllTasksQuery : IRequest<IEnumerable<TaskModelDto>>
{
}
