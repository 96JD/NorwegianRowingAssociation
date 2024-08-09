using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class TestResultRepository(NorwegianRowingAssociationContext context) : GenericRepository<TestResult>(context)
{
	public override IEnumerable<TestResult> FetchAllWhere(Expression<Func<TestResult, bool>> expression)
	{
		return context
			.TestResults.Include(t => t.Test)
			.Include(t => t.TestWeek)
			.Include(t => t.User)
			.Include(t => t.User!.UserClass)
			.Include(t => t.User!.UserClub)
			.Where(expression);
	}

	public override TestResult FetchSingleByKey(int key)
	{
		return context
			.TestResults.Include(t => t.Test)
			.Include(t => t.TestWeek)
			.Include(t => t.User)
			.FirstOrDefault(t => t.Id == key)!;
	}
}
