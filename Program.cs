﻿using HangManSolo;
using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

UserManager u = new();
string username = "user";
string password = "password";
byte[] hashedPassword = u.EncryptPassword(password, out byte[] salt);
u.UserToDb(username, hashedPassword, salt);

double lives = 2.5;

Rune fullLifeIcon = new Rune(0x1F496);
Rune halfLifeIcon = new Rune(0x1F494);

for (int i = 0; i < lives; i++)
{
	Console.Write(fullLifeIcon);
}
Console.WriteLine(halfLifeIcon);