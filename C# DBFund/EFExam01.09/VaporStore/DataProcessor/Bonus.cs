namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            var user = context.Users.Where(u => u.Username == username).FirstOrDefault();

            if (user == null)
            {
                return $"User {username} not found";
            }

            bool emailTaken = context.Users.Any(u => u.Email == newEmail);

            if (emailTaken)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;

            context.SaveChanges();

            return $"Changed {username}'s email successfully";
		}
	}
}
