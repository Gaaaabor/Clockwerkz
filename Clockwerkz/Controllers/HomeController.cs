using Microsoft.AspNetCore.Mvc;

namespace Clockwerkz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
