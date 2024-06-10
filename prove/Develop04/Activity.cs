public class Activity
{
    protected string _title;
    protected string _description;
    protected int duration;

    public Activity(string title, string description)
    {
        _title = title;
        _description = description;
    }

    public void DisplayWelcome()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_title} Activity.");
        Console.WriteLine("\n"+_description);
    }
}