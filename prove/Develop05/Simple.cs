public class Simple : Goal
{
    private Boolean _complete;
    
    // Constructors
    public Simple() {}
    public Simple(string title, string description, int points): base(title, description, points)
    {
        _complete = false;
    }

    // Creates the goal
    public override Simple CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = Program.SelectInput("What is the amount of points associated with this goal? ", 0, 100000);
        return new Simple(title, description, points);
    }
    
    // Displays the goal
    public override void DisplayGoal()
    {
        Console.WriteLine($"{_title}\n{_description}\nPoints: {_points}\nComplete: {_complete}");
    }

    // Record an event
    public override void RecordEvent()
    {
        Console.WriteLine("Simple Goal Event Recorded");
    }
}