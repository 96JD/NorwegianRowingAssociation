using _96JD.PasswordUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;

namespace NorwegianRowingAssociation.Pages;

public class IndexModel(IGenericRepository<User> userRepository) : PageModel
{
	[BindProperty]
	public UserLogin? UserLogin { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser is null)
		{
			return Page();
		}
		return RedirectToPage("TestResults/Index");
	}

	public IActionResult OnPost()
	{
		if (ModelState.IsValid)
		{
			User dbUser;
			dbUser = userRepository.FetchSingleWhere(
				u =>
					u.Email.ToLower().Equals(UserLogin!.Email.ToLower())
					&& u.Password.Equals(PasswordUtils.Encrypt(UserLogin.Password))
			);

			if (dbUser is not null)
			{
				SessionUtils.SetLoggedInUser(HttpContext.Session, dbUser);
				TempData["Success"] = "Logged in successfully!";
				return RedirectToPage("TestResults/Index");
			}
		}
		return Page();
	}

	public IActionResult OnPostTestUser()
	{
		if (!AppSettingsConfigurator.IsDevelopmentEnvironment())
		{
			User dbUser = userRepository.FetchSingleByKey(2);
			if (dbUser is not null)
			{
				SessionUtils.SetLoggedInUser(HttpContext.Session, dbUser);
				TempData["Success"] = "Logged in successfully!";
				return RedirectToPage("TestResults/Index");
			}
		}
		return Page();
	}

	public IActionResult OnPostLogout()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser is not null)
		{
			HttpContext.Session.Clear();
			TempData["Success"] = "Logged out successfully!";
			return RedirectToPage("Index");
		}
		return Page();
	}
}
