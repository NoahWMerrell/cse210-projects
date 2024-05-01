using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        float nmNumber = -1;
        List<float> nmNumbers = new List<float>();
        float nmSum = 0; 
        while (nmNumber != 0){
            Console.Write("Enter number: ");
            string nmNumberStr = Console.ReadLine();
            nmNumber = float.Parse(nmNumberStr);
            nmNumbers.Add(nmNumber);
            nmSum += nmNumber;
        }
        float nmLargest = nmNumbers[0];
        foreach (float nmNumberL in nmNumbers){
            if (nmLargest < nmNumberL){
                nmLargest = nmNumberL;
            }
        }
        float nmAverage = nmSum / (nmNumbers.Count-1);
        Console.WriteLine("The sum is: " + nmSum);
        Console.WriteLine("The average is: " + nmAverage);
        Console.WriteLine("The largest number is: " + nmLargest);
    }
}