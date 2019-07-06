using Clockwerkz.Application.Jobs.Commands;
using Clockwerkz.Application.Jobs.Queries;
using Clockwerkz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            var jobDetails = await Mediator.Send(new ListJobDetailsQuery());
            return Json(jobDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobScheduleCommand jobScheduleCommand)
        {
            var result = await Mediator.Send(jobScheduleCommand);
            return Ok(result);
        }
    }
}
