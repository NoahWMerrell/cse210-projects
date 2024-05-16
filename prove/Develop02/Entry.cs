using System.Reflection;

public class Entry
{
    public DateTime _dateTime;
    public string _input;
    public string _prompt;

    // Entry constructor
    public Entry(DateTime dateTime, string input, string prompt)
    {
        _dateTime = dateTime;
        _input = input;
        _prompt = prompt;
    }

    // Creates an Entry with input
    public static Entry Create()
    {
        DateTime currentDate = DateTime.Now;
        string prompt = Prompt.Generate();
        string input;

        // Display prompt and receive input from user
        Console.WriteLine($"{prompt}");
        input = Console.ReadLine();
        return new Entry(currentDate, input, prompt);
    }

    // Displays an entry
    public static void Display(Entry entry)
    {
        Console.WriteLine($"Created: {entry._dateTime} - Prompt: {entry._prompt}");
        Console.WriteLine($"{entry._input}");
    }
}