using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class UserClassRepository(NorwegianRowingAssociationContext context) : GenericRepository<UserClass>(context) { }
