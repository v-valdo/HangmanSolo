using System.Text;

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
		Console.Clear();
		Console.WriteLine($"\tHey {user.Username}!");
		Random rnd = new();
		string[] wordList = File.ReadAllLines("filteredWords.txt");
		string secretWord = wordList[rnd.Next(0, wordList.Length)];
		Console.WriteLine($"\tThe secret word has been generated and is {secretWord.Length} characters long");
		Console.WriteLine("\tPress any key to start playing...");
		Console.ReadKey();
		Round(secretWord);
	}
	public void Round(string secretWord)
	{
		Console.Clear();
		int lives = 6;
		while (lives > 0)
		{
			Console.WriteLine("Lives left:");
			Rune fullLifeIcon = new Rune(0x1F496);

			for (int i = 0; i < lives; i++)
			{
				Console.Write(fullLifeIcon);
			}
			char[] guessingSpace = new char[secretWord.Length];

			foreach (char c in guessingSpace)
			{
				Console.Write("_ ");
			}

			Console.WriteLine();
			Console.Write("Take a guess!: ");
			if (char.TryParse(Console.ReadLine(), out char g))
			{

			}
		}
	}
}