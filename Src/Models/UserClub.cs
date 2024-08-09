using System.ComponentModel.DataAnnotations;

namespace NorwegianRowingAssociation.Models;

public partial class UserClub
{
	public int Id { get; set; }

	[MaxLength(30)]
	public required string Name { get; set; }

	public virtual ICollection<User> Users { get; set; } = [];
}