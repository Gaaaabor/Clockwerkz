using Clockwerkz.Application.JobTypes.Queries;
using Clockwerkz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobMetadatasController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> JobTypes()
        {
            var jobTypes = await Mediator.Send(new ListJobTypesQuery());
            return Json(jobTypes);
        }

        [HttpGet("[action]/{group}")]
        public async Task<IActionResult> JobDataMapKeys(string group)
        {
            var jobTypes = await Mediator.Send(new ListJobDataMapKeysQuery
            {
                Group = group
            });

            return Json(jobTypes);
        }
    }
}
