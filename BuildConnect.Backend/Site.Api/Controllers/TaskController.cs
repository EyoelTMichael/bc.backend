using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.TaskFeatures.Command;
using Site.Application.Features.TaskFeatures.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;


    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<TaskModelDto>>> GetAll()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateTaskCommand command)
    {
        var materialId = await _mediator.Send(command);
        return Ok(materialId);
    }
}
