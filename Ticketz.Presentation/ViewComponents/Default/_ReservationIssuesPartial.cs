using Microsoft.AspNetCore.Mvc;

namespace Ticketz.Presentation.ViewComponents.Default
{
	public class _ReservationIssuesPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
