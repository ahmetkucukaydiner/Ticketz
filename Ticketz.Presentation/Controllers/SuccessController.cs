using Microsoft.AspNetCore.Mvc;
using Ticketz.Presentation.Models;

namespace Ticketz.Presentation.Controllers
{
    public class SuccessController : Controller
    {
        public IActionResult Index(CheckoutResponseModel model)
        {
            return View(model);
        }
    }
}
