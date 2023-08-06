using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.UserFeature.Command;
using Site.Application.Features.UserFeature.Query;
using Site.Domain.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Site.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;


    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Register")]
    public async Task<ActionResult<Guid>> Register([FromForm] RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
    [HttpGet("Login")]
    public async Task<ActionResult<string>> Login([FromQuery] string userName, [FromQuery] string password)
    {
        var token = await _mediator.Send(new LoginUserQuery { UserName = userName, Password = password});
        return Ok(token);
    }
}