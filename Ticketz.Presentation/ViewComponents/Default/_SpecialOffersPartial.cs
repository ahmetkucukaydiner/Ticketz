using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.ViewComponents.Default
{
    public class _SpecialOffersPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
