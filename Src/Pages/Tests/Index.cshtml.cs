using Microsoft.AspNetCore.Mvc.RazorPages;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Pages.Tests;

public class IndexModel(IGenericRepository<Test> testRepository) : PageModel
{
	public IEnumerable<Test>? AllTests { get; set; }

	public void OnGet()
	{
		AllTests = testRepository.FetchAll();
	}
}
