using System.Text.RegularExpressions;

namespace HangManSolo;

internal class Words
{
	// Use Words.FilterToUpper() to create filtered list: (length > 10 and UPPERCASE)
	public static void FilterToUpper()
	{
		if (!File.Exists("filteredWords.txt"))
		{
			// Insert path to txt-file with words to filter them
			string[] fullDictionary = File.ReadAllLines("words.txt");

			List<string> filteredDictionary = fullDictionary
				.Where(x => x.Length > 10 && Regex.IsMatch(x, "^[a-zA-Z]+$"))
				.Select(x => x.ToUpper())
				.ToList();

			File.AppendAllLines("filteredWords.txt", filteredDictionary);
		}
	}
}
