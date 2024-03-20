using HangManSolo;
using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.WriteLine("Welcome to HangManSolo");
//Console.WriteLine("with encrypted registration, login and score keeping");
//Console.WriteLine("1. Login");
//Console.WriteLine("2. Register");

string username = "user";
string password = "password";

UserManager um = new();

Console.WriteLine(um.Login(username, password));

double lives = 2.5;

Rune fullLifeIcon = new Rune(0x1F496);
Rune halfLifeIcon = new Rune(0x1F494);

for (int i = 0; i < lives; i++)
{
	Console.Write(fullLifeIcon);
}
Console.WriteLine(halfLifeIcon);
