using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class UserRoleRepository(NorwegianRowingAssociationContext context) : GenericRepository<UserRole>(context) { }
