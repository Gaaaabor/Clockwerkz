using Clockwerkz.Application.Triggers.Commands;
using Clockwerkz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwerkz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriggersController : BaseController
    {
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTriggerCommand deleteTriggerCommand)
        {
            var result = await Mediator.Send(deleteTriggerCommand);
            return Ok(result);
        }
    }
}
