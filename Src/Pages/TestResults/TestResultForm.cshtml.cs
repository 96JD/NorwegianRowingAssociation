using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.TestResults;

public class TestResultFormModel(
	IGenericRepository<User> userRepository,
	IGenericRepository<Test> testRepository,
	IGenericRepository<TestWeek> testWeekRepository,
	IGenericRepository<TestResult> testResultRepository
) : PageModel
{
	public IEnumerable<User>? AllUsers { get; set; }
	public IEnumerable<Test>? AllTests { get; set; }
	public IEnumerable<TestWeek>? AllTestWeeks { get; set; }

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

		AllUsers = userRepository.FetchAllWhere(
			u => u.UserRoleId == UserRoleConstants.Practitioner && u.UserClubId == loggedInUser.UserClubId
		);
		AllTests = testRepository.FetchAll();
		AllTestWeeks = testWeekRepository.FetchAll();
		if (Id != 0)
		{
			TestResult = testResultRepository.FetchSingleByKey(Id);
		}
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
			if (Id == 0)
			{
				testResultRepository.Create(TestResult!);
				testResultRepository.SaveChanges();
				TempData["Success"] = "Test result added successfully!";
			}
			else
			{
				TestResult!.UpdatedDate = DateTime.Now;
				testResultRepository.Update(TestResult!);
				testResultRepository.SaveChanges();
				TempData["Success"] = "Test result updated successfully!";
			}
			return RedirectToPage("Index");
		}
		return Page();
	}
}
