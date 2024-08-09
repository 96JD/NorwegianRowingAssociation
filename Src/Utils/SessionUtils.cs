using Newtonsoft.Json;
using NorwegianRowingAssociation.Models;

namespace NorwegianRowingAssociation.Utils;

public static class SessionUtils
{
	public static void SetLoggedInUser(ISession session, User user)
	{
		session.SetString("loggedInUser", JsonConvert.SerializeObject(user));
	}

	public static User? GetLoggedInUser(ISession session)
	{
		string loggedInUser = session.GetString("loggedInUser")!;
		if (string.IsNullOrEmpty(loggedInUser))
		{
			return null;
		}
		return JsonConvert.DeserializeObject<User>(loggedInUser);
	}
}
