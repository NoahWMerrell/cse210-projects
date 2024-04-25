using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for input
        Console.Write("What is your first name? ");
        string nmfirst = Console.ReadLine();
        Console.Write("What is your last name? ");
        string nmlast = Console.ReadLine();

        // Display result
        Console.WriteLine($"\nYour name is {nmlast}, {nmfirst} {nmlast}.");
    }
}