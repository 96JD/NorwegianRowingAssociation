using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Pages.UserClubs;

public class IndexModel(IGenericRepository<UserClub> userClubRepository) : PageModel
{
	public IEnumerable<UserClub>? AllUserClubs { get; set; }

	public void OnGet()
	{
		AllUserClubs = userClubRepository.FetchAll();
	}
}
