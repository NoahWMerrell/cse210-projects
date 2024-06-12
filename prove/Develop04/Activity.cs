public class Activity
{
    protected string _title;
    protected string _description;
    protected int _duration;

    // Constructor
    public Activity(string title, string description)
    {
        _title = title;
        _description = description;
    }

    // Displays the welcome message for the activity
    public void DisplayWelcome()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_title} Activity.");
        Console.WriteLine("\n"+_description);
        SelectDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Animation(3);
    }

    // Displays the ending message for the activity
    public void DisplayEnd()
    {
        Console.WriteLine("\n\nWell done!");
        Animation(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_title} Activity.");
        Animation(5);
    }

    // Allows the user to enter the duration in seconds
    public void SelectDuration()
    {
        _duration = Program.SelectInput("\nHow long, in seconds, would you like for your session? ", 10, 3600);
    }

    // Displays countdown for specified seconds
    public static void Countdown(int sec)
    {
        for (int i = sec; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Runs spinning animation for specified seconds
    public static void Animation(int sec)
    {
        DateTime endTime = DateTime.Now.AddSeconds(sec);

        while (DateTime.Now < endTime)
        {
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
}