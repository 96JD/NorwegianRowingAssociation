using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class TestWeekRepository(NorwegianRowingAssociationContext context) : GenericRepository<TestWeek>(context) { }
