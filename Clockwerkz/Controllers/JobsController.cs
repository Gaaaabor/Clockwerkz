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
        [HttpGet("[action]")]
        public async Task<IActionResult> Preview()
        {
            var jobPreviews = await Mediator.Send(new ListJobPreviewsQuery());
            return Json(jobPreviews);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateJobs()
        {
            var result = await Mediator.Send(new CreateJobCommand());
            return Ok(result);
        }
    }
}
