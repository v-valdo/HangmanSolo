using HangManSolo;
using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
	Console.Clear();
	Console.WriteLine("\tWelcome to HangManSolo");
	Console.WriteLine("\twith encrypted registration, login and score keeping");
	Console.WriteLine();
	Console.WriteLine("\t1. Login");
	Console.WriteLine("\t2. Register");

	char userInput = Console.ReadKey().KeyChar;
	Menu menu = new();

	switch (userInput)
	{
		case '2':
			await menu.RegisterAsync();
			break;
		default:
			break;
	}
}

double lives = 2.5;

Rune fullLifeIcon = new Rune(0x1F496);
Rune halfLifeIcon = new Rune(0x1F494);

for (int i = 0; i < lives; i++)
{
	Console.Write(fullLifeIcon);
}
Console.WriteLine(halfLifeIcon);
