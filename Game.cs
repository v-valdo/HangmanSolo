namespace HangManSolo;
public class Game
{
	private readonly User user;
	public Game(User user)
	{
		this.user = user;
	}
	public void Play()
	{
		Console.WriteLine($"Hey {user.Username}");
	}
}
