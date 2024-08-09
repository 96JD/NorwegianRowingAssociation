using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Pages.UserClasses;

public class IndexModel(IGenericRepository<UserClass> userClassRepository) : PageModel
{
	public IEnumerable<UserClass>? AllUserClasses { get; set; }

	public void OnGet()
	{
		AllUserClasses = userClassRepository.FetchAll();
	}
}
