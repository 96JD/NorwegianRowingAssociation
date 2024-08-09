using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Constants;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;
using NorwegianRowingAssociation.Utils;
using _96JD.PasswordUtils;

namespace NorwegianRowingAssociation.Pages.Users;

public class UserFormModel(
	IGenericRepository<UserClass> userClassRepository,
	IGenericRepository<UserRole> userRoleRepository,
	IGenericRepository<User> userRepository
) : PageModel
{
	public IEnumerable<UserClass>? AllUserClasses { get; set; }

	public IEnumerable<UserRole>? AllUserRoles { get; set; }

	[BindProperty]
	public new User? User { get; set; }

	public IActionResult OnGet()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Trainer)
		{
			return RedirectToPage("Index");
		}

		AllUserClasses = userClassRepository.FetchAll();
		AllUserRoles = userRoleRepository.FetchAllWhere(u => u.Id != UserRoleConstants.Admin);
		return Page();
	}

	public IActionResult OnPost()
	{
		User loggedInUser = SessionUtils.GetLoggedInUser(HttpContext.Session)!;
		if (loggedInUser.UserRoleId != UserRoleConstants.Trainer)
		{
			return RedirectToPage("Index");
		}

		User dbUser = userRepository.FetchSingleWhere(u => u.Email.ToLower().Equals(User!.Email.ToLower()));
		if (dbUser is not null)
		{
			TempData["Error"] = "Email already in use!";
			return RedirectToPage("Create");
		}
		else
		{
			string password = User!.Password;
			string passwordConfirm = Request.Form["password-confirm"]!;
			if (password.Equals(passwordConfirm))
			{
				string url = ImageHandler.UploadImage($"{User!.Email}/", User.Image);
				User.ImageUrl = url;
				User.UserClubId = loggedInUser.UserClubId;

				TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
				User.FirstName = textInfo.ToTitleCase(User.FirstName);
				User.LastName = textInfo.ToTitleCase(User.LastName);

				User.Email = User.Email.ToLower();
				User.Password = PasswordUtils.Encrypt(password);

				userRepository.Create(User);
				userRepository.SaveChanges();
				TempData["Success"] = "User added successfully!";
				return RedirectToPage("Index");
			}
			else
			{
				TempData["Error"] = "Passwords must match!";
				return RedirectToPage("Create");
			}
		}
	}
}
