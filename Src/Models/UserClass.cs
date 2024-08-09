using System.ComponentModel.DataAnnotations;

namespace NorwegianRowingAssociation.Models;

public partial class UserClass
{
	public int Id { get; set; }

	[MaxLength(25)]
	public required string Name { get; set; }

	public virtual ICollection<User> Users { get; set; } = [];
}