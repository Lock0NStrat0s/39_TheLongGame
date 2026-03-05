namespace TheLongGame;

/*Objectives:
    • When the program starts, ask the user to enter their name.
    • By default, the player starts with a score of 0.
    • Add 1 point to their score for every keypress they make.
    • Display the player’s updated score after each keypress.
    • When the player presses the Enter key, end the game. Hint: the following code reads a keypress and
    checks whether it was the Enter key: Console.ReadKey().Key == ConsoleKey.Enter
    • When the player presses Enter, save their score in a file. Hint: Consider saving this to a file named
    [username].txt. For this challenge, you can assume the user doesn’t enter a name that would produce
    an illegal file name (such as *).
    • When a user enters a name at the start, if they already have a previously saved score, start with that
score instead.*/

class Program
{
    static void Main(string[] args)
    {
        string userName;
        ConsoleKey userInput;
        int userScore = 0;

        Console.Write("What is your name? ");
        userName = Console.ReadLine();

        if (File.Exists($"User/{userName}.txt"))
        {
            FileStream streamOpen = File.Open($"User/{userName}.txt", FileMode.Open);
            StreamReader reader = new StreamReader(streamOpen);
            userScore = int.Parse(reader.ReadLine());
            reader.Close();
        }
        else
        {
            File.Create($"User/{userName}.txt").Close();
        }

        FileStream stream = File.Open($"User/{userName}.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(stream);

        Console.Write($"\nWelcome {userName}! ");
        
        do
        {
            Console.WriteLine($"\nYour Score is {userScore}");

            Console.Write("\nEnter any key to earn 1 point: ");
            userInput = Console.ReadKey().Key;
        
            if (userInput != ConsoleKey.Enter)
            {
                userScore++;
            }
        } while (userInput != ConsoleKey.Enter);
        
        writer.WriteLine(userScore);
        writer.Close();
    }
}