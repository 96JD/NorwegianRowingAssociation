using Microsoft.AspNetCore.Mvc;

namespace NorwegianRowingAssociation.Components;

public class EditButtonViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(string title, string route, string id)
	{
		ViewData["title"] = title;
		ViewData["route"] = route;
		ViewData["id"] = id;
		return View();
	}
}
