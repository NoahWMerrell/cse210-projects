using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for input
        // First name
        Console.Write("What is your first name? ");
        string nmfirst = Console.ReadLine();
        // Last name
        Console.Write("What is your last name? ");
        string nmlast = Console.ReadLine();

        // Display result
        Console.WriteLine($"\nYour name is {nmlast}, {nmfirst} {nmlast}.");
    }
}