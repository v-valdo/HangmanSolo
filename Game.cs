using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HangManSolo
{
    public class Game
    {
        private readonly User user;
        private readonly DbContext db;
        public Game(User user, DbContext db)
        {
            this.user = user;
            this.db = db;
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
            secretWord = secretWord.ToUpper();

            Console.Clear();
            int lives = 6;
            StringBuilder guessedLetters = new StringBuilder();
            while (lives > 0)
            {
                Console.Clear();
                Console.WriteLine($"Lives left: {lives}");
                Rune fullLifeIcon = new Rune(0x1F496);

                for (int i = 0; i < lives; i++)
                {
                    Console.Write(fullLifeIcon);
                }

                char[] guessingSpace = new char[secretWord.Length];

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (guessedLetters.ToString().Contains(secretWord[i]))
                    {
                        guessingSpace[i] = secretWord[i];
                    }
                    else
                    {
                        guessingSpace[i] = '_';
                    }
                }

                Console.WriteLine();
                Console.WriteLine(string.Join(" ", guessingSpace));

                Console.Write("Guess a letter: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid guess.");
                    Thread.Sleep(200);
                    continue;
                }

                char guessedChar = char.ToUpper(input[0]);
                guessedLetters.Append(guessedChar);

                if (!secretWord.Contains(guessedChar))
                {
                    lives--;
                }

                if (secretWord.All(letter => guessedLetters.ToString().Contains(letter)))
                {
                    Console.WriteLine($"You guessed the word: {secretWord}! You have received {secretWord.Length} points.");
                    try
                    {
                        user.Score += secretWord.Length;
                        user.GamesPlayed++;
                        db.SaveChanges();
                        Console.WriteLine("Score updated!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                }
            }

            if (lives == 0)
            {
                Console.Clear();
                Console.WriteLine("The man was hung to death. The word was: " + secretWord);
                user.GamesPlayed++;
                db.SaveChanges();
                Console.WriteLine("Game over. Score not updated.");
                Console.ReadKey();
            }
        }
    }
}