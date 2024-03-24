using Microsoft.EntityFrameworkCore;

namespace HangManSolo;
public class Menu
{
	GameDbContext db = new();
	public async Task RegisterAsync()
	{
		while (true)
		{
			Console.Clear();
			Console.Write("Username:");
			string username = Console.ReadLine() ?? "0";

			var checkUsername = await db.Users.FirstOrDefaultAsync(x => x.Username == username);
			if (checkUsername != null)
			{
				Console.WriteLine("Username already exists! Try again..");
				Thread.Sleep(500);
				continue;
			}

			Console.Write("Password:");
			string password = Console.ReadLine() ?? "0";
			UserManager u = new();
			try
			{
				var passwordHash = u.EncryptPassword(password, out byte[] salt);
				await u.UserToDb(username, passwordHash, salt);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}

			Console.WriteLine("User successfully registered! Press any key to return");
			Console.ReadKey();
			break;
		}
	}
}
