using Clockwerkz.Application.Jobs.Commands;
using Clockwerkz.Application.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Angular.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List(string schedulerName, string jobName, string groupName)
        {
            var jobs = await _mediator.Send(new ListJobsQuery
            {
                SchedulerName = schedulerName,
                JobName = jobName,
                GroupName = groupName
            });

            return Ok(jobs);
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
