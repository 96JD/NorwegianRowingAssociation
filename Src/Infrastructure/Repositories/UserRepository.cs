using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class UserRepository(NorwegianRowingAssociationContext context) : GenericRepository<User>(context)
{
	public override IEnumerable<User> FetchAll()
	{
		return context.Users.Include(u => u.UserClass).Include(u => u.UserClub).Include(u => u.UserRole);
	}

	public override IEnumerable<User> FetchAllWhere(Expression<Func<User, bool>> expression)
	{
		return context
			.Users.Include(u => u.UserClass)
			.Include(u => u.UserClub)
			.Include(u => u.UserRole)
			.Where(expression);
	}
}
