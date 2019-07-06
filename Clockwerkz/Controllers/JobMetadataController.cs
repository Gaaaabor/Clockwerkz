using Clockwerkz.Application.JobTypes.Queries;
using Clockwerkz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobMetadataController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> JobTypes()
        {
            var jobTypes = await Mediator.Send(new ListJobTypesQuery());
            return Json(jobTypes);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DefaultJobDataMapKeys()
        {
            var jobTypes = await Mediator.Send(new ListDefaultJobDataMapKeysQuery());
            return Json(jobTypes);
        }
    }
}
