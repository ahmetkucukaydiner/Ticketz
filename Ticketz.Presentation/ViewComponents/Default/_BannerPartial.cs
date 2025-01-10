using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.ViewComponents.Default
{
	public class _BannerPartial : ViewComponent
	{
		public IViewComponentResult Invoke() 
		{ 
			return View(); 
		}
	}
}
