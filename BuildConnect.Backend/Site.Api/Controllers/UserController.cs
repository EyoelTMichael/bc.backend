using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.UserFeature.Command;
using Site.Application.Features.UserFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;


    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<UserDto>> Get([FromQuery] Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        return Ok(user);
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    //[HttpPost]
    //public async Task<ActionResult<Guid>> Create([FromForm] RegisterUserCommand command)
    //{
    //    var userId = await _mediator.Send(command); 
    //    return Ok(userId);
    //}

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateUserCommand command)
    {
        command.Id = id;
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    [HttpDelete]
    public async Task<Unit> Delete(DeleteUserCommand command)
    {
        await _mediator.Send(command);
        return Unit.Value;
    }
    
}
