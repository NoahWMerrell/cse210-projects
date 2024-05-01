using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        // string nmNumberStr = Console.ReadLine();
        // int nmNumber = int.Parse(nmNumberStr);

        // Generate random number
        Random randomGenerator = new Random();
        int nmNumber = randomGenerator.Next(1, 101);
        int nmGuess = 0;
        while (nmGuess != nmNumber)
        {
            // Ask user for guess
            Console.Write("What is your guess? ");
            string nmGuessStr = Console.ReadLine();
            nmGuess = int.Parse(nmGuessStr);

            // Determines how guess compares to number
            if (nmGuess < nmNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (nmGuess > nmNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        
    }
}