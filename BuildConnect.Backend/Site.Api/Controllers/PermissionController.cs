using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.PermissionFeatures.Command;
using Site.Application.Features.PermissionFeatures.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IMediator _mediator;

        public PermissionController(ILogger<PermissionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<PermissionDto>> Get([FromQuery] Guid id)
        {
            var permission = await _mediator.Send(new GetPermissionQuery { Id = id });
            return Ok(permission);
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetAll()
        {
            var permissions = await _mediator.Send(new GetAllPermissionsQuery());
            return Ok(permissions);
        }
        //[HttpPost]
        //public async Task<ActionResult<Guid>> Create(CreatePermissionCommand command)
        //{
        //    var permissionId = await _mediator.Send(command);
        //    return Ok(permissionId);
        //}
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePermission(CreatePermissionCommand command)
        {
            var permissionId = await _mediator.Send(command);

            return Ok(permissionId);
        }
    }
}
