using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.ViewComponents.Default
{
	public class _BlogAreaPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
