using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for input
        Console.Write("What is your grade percentage? ");
        string nmgradeAnswer = Console.ReadLine();
        int nmgrade = int.Parse(nmgradeAnswer);

        string nmletter;
        if (nmgrade >= 90)
        {
            nmletter = "A";
        }
        else if (nmgrade >= 80)
        {
            nmletter = "B";
        }
        else if (nmgrade >= 70)
        {
            nmletter = "C";
        }
        else if (nmgrade >= 60)
        {
            nmletter = "D";
        }
        else
        {
            nmletter = "F";
        }
        
        Console.WriteLine($"Grade: {nmletter}");
        if (nmgrade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }
    }
}