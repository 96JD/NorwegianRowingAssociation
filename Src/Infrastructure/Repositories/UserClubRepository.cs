using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Infrastructure.Repositories;

public class UserClubRepository(NorwegianRowingAssociationContext context) : GenericRepository<UserClub>(context) { }
