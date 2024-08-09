using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Pages.TestWeeks;

public class IndexModel(IGenericRepository<TestWeek> testWeekRepository) : PageModel
{
	public IEnumerable<TestWeek>? AllTestWeeks { get; set; }

	public void OnGet()
	{
		AllTestWeeks = testWeekRepository.FetchAll();
	}
}
