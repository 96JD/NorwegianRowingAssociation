using Microsoft.AspNetCore.Mvc;

namespace NorwegianRowingAssociation.Components;

public class LegendViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(string title)
	{
		ViewData["title"] = title;
		return View();
	}
}
