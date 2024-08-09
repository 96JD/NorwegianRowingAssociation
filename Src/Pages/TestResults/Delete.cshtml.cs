using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.TestResults;

public class DeleteModel(IGenericRepository<TestResult> testResultRepository) : PageModel
{
	[FromRoute]
	public int Id { get; set; }

	[BindProperty]
	public TestResult? TestResult { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Trainer)
		{
			return RedirectToPage("Index");
		}

		TestResult = testResultRepository.FetchSingleByKey(Id);
		return Page();
	}

	public IActionResult OnPost()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Trainer)
		{
			return RedirectToPage("Index");
		}

		if (ModelState.IsValid)
		{
			testResultRepository.Delete(TestResult!);
			testResultRepository.SaveChanges();
			TempData["Success"] = "Test result deleted successfully!";
			return RedirectToPage("Index");
		}
		return Page();
	}
}
