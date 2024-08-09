using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorwegianRowingAssociation.Models;

public partial class User
{
	public int Id { get; set; }

	[NotMapped]
	public required IFormFile Image { get; set; }

	public required string ImageUrl { get; set; }

	public required string FirstName { get; set; }

	public required string LastName { get; set; }

	[RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid email format.")]
	public required string Email { get; set; }

	public int YearOfBirth { get; set; }

	[RegularExpression(
		@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@@#$%^&+=]).{8,}$",
		ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit."
	)]
	public required string Password { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdatedDate { get; set; }

	public int? UserClassId { get; set; }

	public int? UserClubId { get; set; }

	public int UserRoleId { get; set; }

	public virtual UserClass? UserClass { get; set; }

	public virtual UserClub? UserClub { get; set; }

	public virtual UserRole? UserRole { get; set; }

	public virtual ICollection<TestResult> TestResults { get; set; } = [];
}

public partial class UserLogin
{
	[RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid email format.")]
	public required string Email { get; set; }

	[RegularExpression(
		@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@@#$%^&+=]).{8,}$",
		ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit."
	)]
	public required string Password { get; set; }
}