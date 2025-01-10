using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.ViewComponents.Default
{
	public class _HomeAboutPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
