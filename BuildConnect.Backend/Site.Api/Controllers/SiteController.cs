using Microsoft.AspNetCore.Mvc;
using MediatR;
using Site.Application.Features.SiteFeatures.Command;
using Site.Application.Features.SiteFeatures.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        

        private readonly ILogger<SiteController> _logger;
        private readonly IMediator _mediator;

        public SiteController(ILogger<SiteController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<SiteDto>> Get([FromQuery] Guid id)
        {
            var site = await _mediator.Send(new GetSiteQuery { Id = id });
            return Ok(site);
        }
        
        [HttpPost]
        public async Task<ActionResult<SiteDto>> Create(CreateSiteCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
        [HttpPut]
        public async Task<ActionResult<SiteDto>> Update(UpdateSiteCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete(DeleteSiteCommand command)
        {
            var siteId = await _mediator.Send(command);
            return Ok(siteId);
        }
    }
}