using System.ComponentModel.DataAnnotations;

namespace NorwegianRowingAssociation.Models;

public partial class Test
{
	public int Id { get; set; }

	[MinLength(5), MaxLength(25)]
	public required string Name { get; set; }

	public virtual ICollection<TestResult> TestResults { get; set; } = [];
}