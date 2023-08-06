using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.RoleFeatures.Command;
using Site.Application.Features.RoleFeatures.Query;
using Site.Application.Features.SiteFeatures.Command;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController: ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;

        public RoleController(ILogger<RoleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<RoleDto>> Get([FromQuery] Guid id)
        {
            var role = await _mediator.Send(new GetRoleQuery { Id = id });
            return Ok(role);
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            return Ok(roles);
        }
        [HttpGet("permissions")]
        public async Task<ActionResult<List<PermissionDto>>> GetPermissions([FromQuery] Guid id)
        {
            var permissions = await _mediator.Send(new GetPermissionsByRoleIdQuery { RoleId = id});
            return Ok(permissions);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateRoleCommand command)
        {
            var roleId = await _mediator.Send(command);
            return Ok(roleId);
        }
    }
}
