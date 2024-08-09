using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.Tests;

public class TestFormModel(IGenericRepository<Test> testRepository) : PageModel
{
	[FromRoute]
	public int Id { get; set; }

	[BindProperty]
	public Test? Test { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Admin)
		{
			return RedirectToPage("Index");
		}

		if (Id != 0)
		{
			Test = testRepository.FetchSingleByKey(Id);
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
				testRepository.Create(Test!);
				testRepository.SaveChanges();
				TempData["Success"] = "Test added successfully!";
			}
			else
			{
				testRepository.Update(Test!);
				testRepository.SaveChanges();
				TempData["Success"] = "Test updated successfully!";
			}
			return RedirectToPage("Index");
		}
		return Page();
	}
}
