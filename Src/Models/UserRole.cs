using System.ComponentModel.DataAnnotations;

namespace NorwegianRowingAssociation.Models;

public partial class UserRole
{
	public int Id { get; set; }

	[MinLength(5), MaxLength(15)]
	public required string Name { get; set; }

	public virtual ICollection<User> Users { get; set; } = [];
}