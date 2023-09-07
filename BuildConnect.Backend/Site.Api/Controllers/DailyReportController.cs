using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.DailyReportFeature.Command;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyReportController: ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<DailyReportDTO>> Create(CreateDailyReportCommand command)
        {
            var dailyReport = await _mediator.Send(command);
            return Ok(dailyReport);
        }
    }
}
