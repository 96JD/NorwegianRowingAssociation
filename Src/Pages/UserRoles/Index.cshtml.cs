using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Pages.UserRoles;

public class IndexModel(IGenericRepository<UserRole> userRoleRepository) : PageModel
{
	public IEnumerable<UserRole>? AllUserRoles { get; set; }

	public void OnGet()
	{
		AllUserRoles = userRoleRepository.FetchAll().OrderBy(ur => ur.Id);
	}
}
