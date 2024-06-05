using System;

class Program
{
    static void Main(string[] args)
    {
        // Example math assignment
        MathAssignment fraction = new MathAssignment("Robert Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(fraction.GetSummary());
        Console.WriteLine(fraction.GetHomeworkList());
        Console.WriteLine();

        // Example writing assignment
        WritingAssignment europeanHistory = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(europeanHistory.GetSummary());
        Console.WriteLine(europeanHistory.GetWritingInformation());
    }
}