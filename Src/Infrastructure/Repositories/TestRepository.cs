using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class TestRepository(NorwegianRowingAssociationContext context) : GenericRepository<Test>(context) { }
