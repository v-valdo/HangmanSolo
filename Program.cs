using HangManSolo;

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
        case '1':
            await menu.Login();
            break;
        default:
            break;
    }
}