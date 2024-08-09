using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages.UserClubs;

public class UserClubFormModel(IGenericRepository<UserClub> userClubRepository) : PageModel
{
	[FromRoute]
	public int Id { get; set; }

	[BindProperty]
	public UserClub? UserClub { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Admin)
		{
			return RedirectToPage("Index");
		}

		if (Id != 0)
		{
			UserClub = userClubRepository.FetchSingleByKey(Id);
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
				userClubRepository.Create(UserClub!);
				userClubRepository.SaveChanges();
				TempData["Success"] = "User Club added successfully!";
			}
			else
			{
				userClubRepository.Update(UserClub!);
				userClubRepository.SaveChanges();
				TempData["Success"] = "User Club updated successfully!";
			}
			return RedirectToPage("Index");
		}
		return Page();
	}
}
