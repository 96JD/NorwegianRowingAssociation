using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.Users;

public class IndexModel(IGenericRepository<User> userRepository) : PageModel
{
	public IEnumerable<User>? AllUsers { get; set; }

	public void OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId == UserRoleConstants.Admin)
		{
			AllUsers = userRepository.FetchAll().OrderBy(u => u.UserRoleId);
		}
		else
		{
			AllUsers = userRepository.FetchAllWhere(u => u.UserClubId == loggedInUser.UserClubId);
		}
	}
}
