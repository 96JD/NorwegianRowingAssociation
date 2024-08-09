using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.TestResults;

public class IndexModel(IGenericRepository<TestResult> testResultRepository) : PageModel
{
	public IEnumerable<TestResult>? AllTestResults { get; set; }

	public void OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId == UserRoleConstants.Admin)
		{
			AllTestResults = testResultRepository.FetchAllWhere(
				t => t.User!.UserRoleId == UserRoleConstants.Practitioner
			);
		}
		else
		{
			AllTestResults = testResultRepository.FetchAllWhere(
				t =>
					t.User!.UserRoleId == UserRoleConstants.Practitioner && t.User.UserClubId == loggedInUser.UserClubId
			);
		}
	}
}
