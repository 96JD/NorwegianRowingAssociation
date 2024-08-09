using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.TestWeeks;

public class TestWeekFormModel(IGenericRepository<TestWeek> testWeekRepository) : PageModel
{
	[FromRoute]
	public int Id { get; set; }

	[BindProperty]
	public TestWeek? TestWeek { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Admin)
		{
			return RedirectToPage("Index");
		}

		if (Id != 0)
		{
			TestWeek = testWeekRepository.FetchSingleByKey(Id);
		}
		return Page();
	}

	public IActionResult OnPost()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Admin)
		{
			return RedirectToPage("Index");
		}

		if (ModelState.IsValid)
		{
			if (Id == 0)
			{
				testWeekRepository.Create(TestWeek!);
				testWeekRepository.SaveChanges();
				TempData["Success"] = "Test Week added successfully!";
			}
			else
			{
				testWeekRepository.Update(TestWeek!);
				testWeekRepository.SaveChanges();
				TempData["Success"] = "Test Week updated successfully!";
			}
			return RedirectToPage("Index");
		}
		return Page();
	}
}
