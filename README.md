# Summary
Console based Hangman game in C# with encrypted registration/login and score keeping utilizing:
- Npgsql
- .NET Cryptography
- Entity Framework

Run code by:
1. changing the connection string to your postgres db
2. adding a .txt file consisting of words to the solution and running the method Words.FilterToUpper()

configure the filtering method freely in the Words class

by default it filters out words under 10 chars

# Screenshots

![alt text](https://i.imgur.com/FzPuVCF.jpeg)

## Database snap of encrypted user logins:
![db](https://i.imgur.com/ACQtGrA.png)
