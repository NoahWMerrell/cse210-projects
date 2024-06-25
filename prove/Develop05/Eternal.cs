public class Eternal : Goal
{
    // Constructors
    public Eternal() {}
    public Eternal(string title, string description, int points): base(title, description, points) {}

    // Creates the goal
    public override Eternal CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = Program.SelectInput("What is the amount of points associated with this goal? ", 0, 100000);
        return new Eternal(title, description, points);
    }
    
    // Displays the goal
    public override void DisplayGoal()
    {
        Console.Write($"[∞] {_title} ({_description})");
    }

    // Record an event
    public override int RecordEvent()
    {
        Console.WriteLine($"You finished '{_title}' and earned {_points} points!");
        return _points;
    }
}