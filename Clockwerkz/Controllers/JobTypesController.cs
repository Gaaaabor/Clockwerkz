using Clockwerkz.Application.JobTypes.Queries;
using Clockwerkz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobTypesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobTypes = await Mediator.Send(new ListJobTypesQuery());
            return Json(jobTypes);
        }
    }
}
