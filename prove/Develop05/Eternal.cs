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
    public override int RecordEvent(List<Goal> goals)
    {
        Console.WriteLine($"You finished '{_title}' and earned {_points} points!");
        return _points;
    }

    // Writes to the Stream (for saving)
    public override void WriteStream(StreamWriter writer)
    {
        writer.WriteLine($"Eternal,{_title},{_description},{_points}");
    }

    // Reads the Stream (for loading)
    public override void ReadStream(string[] attributes)
    {
        _title = attributes[1];
        _description = attributes[2];
        _points = int.Parse(attributes[3]);
    }
}