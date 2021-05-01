using Clockwerkz.Application.Triggers.Commands;
using Clockwerkz.Application.Triggers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Angular.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriggersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TriggersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string jobName, string jobGroup)
        {
            var triggers = await _mediator.Send(new GetJobTriggersQuery
            {
                JobName = jobName,
                JobGroup = jobGroup
            });

            return Ok(triggers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTriggerCommand createTriggerCommand)
        {
            var result = await _mediator.Send(createTriggerCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTriggerCommand deleteTriggerCommand)
        {
            var result = await _mediator.Send(deleteTriggerCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PauseTriggerCommand pauseTriggerCommand)
        {
            var result = await _mediator.Send(pauseTriggerCommand);
            return Ok(result);
        }
    }
}
