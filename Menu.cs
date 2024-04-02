using Microsoft.EntityFrameworkCore;

namespace HangManSolo;
public class Menu
{
	GameDbContext db = new();
	UserManager u = new();
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
	public async Task<string> Login()
	{
		while (true)
		{
			Console.Clear();
			Console.Write("Username: ");
			string username = Console.ReadLine() ?? "0";
			Console.Write("Password: ");
			string password = Console.ReadLine() ?? "0";

			if (await u.Login(username, password))
			{
				Console.WriteLine($"User {username} successfully logged in...");
				Console.WriteLine("Press any key to continue");
				Console.ReadKey();
				return username;
			}
			else
			{
				Console.WriteLine("User not found!");
				Thread.Sleep(300);
				continue;
			}

		}
	}

	public async Task PlayerMenu(User user)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("\tGame Menu");
			Console.WriteLine("\t1. Play a game");
			Console.WriteLine("\t2. View your score");
			Console.WriteLine("\t3. View high score");
			if (int.TryParse(Console.ReadLine(), out int c))
			{
				switch (c)
				{
					case 1:
						break;
					case 2:
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid choice!");
			}
		}
	}
}
