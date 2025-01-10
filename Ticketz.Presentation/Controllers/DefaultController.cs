using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
