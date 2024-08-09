using Microsoft.AspNetCore.Mvc;

namespace NorwegianRowingAssociation.Components;

public class SubmitButtonViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(string label)
	{
		ViewData["label"] = label;
		return View();
	}
}
