using System;

class Program
{
    static void DisplayWelcome()
    {
        // Displays a welcome message
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        // Asks for and returns user's name
        Console.Write("Please enter your name: ");
        string nmName = Console.ReadLine();
        return nmName;
    }

    static int PromptUserNumber()
    {
        // Asks for and returns user's favorite number
        Console.Write("Please enter your favorite number: ");
        string nmNumberStr = Console.ReadLine();
        int nmNumber = int.Parse(nmNumberStr);
        return nmNumber;
    }

    static int SquareNumber(int nmNumber)
    {
        // Returns number squared
        int nmNumberSquared = nmNumber*nmNumber;
        return nmNumberSquared;
    }

    static void DisplayResult(string nmName, int nmNumberSquared)
    {
        // Displays the user's name and squared number
        Console.WriteLine($"{nmName}, the square of your number is {nmNumberSquared}");
    }

    static void Main(string[] args)
    {
        // Calls various functions
        DisplayWelcome();
        string nmName = PromptUserName();
        int nmNumber = PromptUserNumber();
        int nmNumberSquared = SquareNumber(nmNumber);
        DisplayResult(nmName, nmNumberSquared);
    }
}