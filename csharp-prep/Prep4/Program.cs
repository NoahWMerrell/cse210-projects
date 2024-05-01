using System;

class Program
{
    static void Main(string[] args)
    {
        // Message for user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Initialize variables
        float nmNumber = -1;
        List<float> nmNumbers = new List<float>();
        float nmSum = 0; 

        // Ask user for numbers and add to list
        while (nmNumber != 0){
            Console.Write("Enter number: ");
            string nmNumberStr = Console.ReadLine();
            nmNumber = float.Parse(nmNumberStr);
            nmNumbers.Add(nmNumber);

            // Add number to sum
            nmSum += nmNumber;
        }

        // Find largest number
        float nmLargest = nmNumbers[0];
        foreach (float nmNumberL in nmNumbers){
            if (nmLargest < nmNumberL){
                nmLargest = nmNumberL;
            }
        }

        // Calculate average
        float nmAverage = nmSum / (nmNumbers.Count-1);

        // Display results
        Console.WriteLine("The sum is: " + nmSum);
        Console.WriteLine("The average is: " + nmAverage);
        Console.WriteLine("The largest number is: " + nmLargest);
    }
}