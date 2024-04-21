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
            string password = ReadAndHidePassword() ?? "0";
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
    public async Task Login()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine() ?? "0";
            Console.Write("Password: ");
            string password = ReadAndHidePassword() ?? "0";

            if (await u.Login(username, password))
            {
                Console.WriteLine($"User {username} successfully logged in...");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                await PlayerMenu(username);
            }
            else
            {
                Console.WriteLine("User not found!");
                Thread.Sleep(300);
                continue;
            }
        }
    }

    private string ReadAndHidePassword()
    {
        string password = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
    public async Task PlayerMenu(string username)
    {
        while (true)
        {
            User? user = await db.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"\tWelcome {username}!");
                Console.WriteLine("\tGame Menu");
                Console.WriteLine("\t1. Play a game");
                Console.WriteLine("\t2. View your score");
                Console.WriteLine("\t3. View high score");

                if (int.TryParse(Console.ReadLine(), out int c))
                {
                    switch (c)
                    {
                        case 1:
                            Game round = new(user, db);
                            round.Play();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine($"Your score is: {user.Score}");
                            Console.WriteLine("Games played: " + user.GamesPlayed);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            break;
                        case 3:
                            HighScore();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            else
            {
                Console.WriteLine("Weird...your user wasn't found...");
                Console.WriteLine("Press any key to exit to main menu");
                Console.ReadKey();
                break;
            }
        }
    }

    public void HighScore()
    {
        Console.Clear();
        IEnumerable<User> highscore = db.Users.OrderByDescending(x => x.Score);
        foreach (var user in highscore)
        {
            Console.WriteLine($"Username: {user.Username} | Score: {user.Score}");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}
