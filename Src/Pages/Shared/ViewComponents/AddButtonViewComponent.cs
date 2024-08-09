using Microsoft.AspNetCore.Mvc;

namespace NorwegianRowingAssociation.Components;

public class AddButtonViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(string title, string route)
	{
		ViewData["title"] = title;
		ViewData["route"] = route;
		return View();
	}
}
