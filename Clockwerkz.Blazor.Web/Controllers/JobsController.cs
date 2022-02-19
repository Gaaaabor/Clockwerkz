using Clockwerkz.Application.Jobs.Commands;
using Clockwerkz.Application.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clockwerkz.Blazor.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string jobName, string groupName)
        {
            var jobDetails = await _mediator.Send(new JobDetailsQuery
            {
                JobName = jobName,
                GroupName = groupName
            });

            return Ok(jobDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ScheduleJobCommand scheduleJobCommand)
        {
            var scheduledJob = await _mediator.Send(scheduleJobCommand);
            return Ok(scheduledJob);
        }

        [HttpDelete]
        public async Task<IActionResult> Get(DeleteJobCommand deleteJobCommand)
        {
            var result = await _mediator.Send(deleteJobCommand);
            return Ok(result);
        }
    }
}
