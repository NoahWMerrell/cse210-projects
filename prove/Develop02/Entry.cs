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
    public static Entry Create(string input)
    {
        DateTime currentDate = DateTime.Now;
        string prompt = Prompt.Generate();
        return new Entry(currentDate, input, prompt);
    }

    public static string GetEntry()
    {
        return "test";
    }

    // Displays an entry
    public static void Display(Entry entry)
    {
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.WriteLine($"Created: {entry._dateTime}");
        Console.WriteLine($"{entry._input}");
    }
}