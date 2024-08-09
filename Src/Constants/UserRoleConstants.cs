using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Constants;

public static class UserRoleConstants
{
	public static readonly string ModelName = typeof(UserRole).Name;

	public const int Admin = 1;
	public const int Trainer = 2;
	public const int Practitioner = 3;
}
