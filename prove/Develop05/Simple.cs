
using System.Runtime.CompilerServices;

public class Simple : Goal
{
    // Attributes
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
        if (_complete == false)
        {
            Console.Write("[ ]");
        }
        else
        {
            Console.Write("[X]");
        }
        Console.Write($" {_title} ({_description})");
    }

    // Record an event
    public override int RecordEvent(List<Goal> goals)
    {
        int points = 0;
        if (_complete == false)
        {
            _complete = true;
            points = _points;
            Console.WriteLine($"You finished '{_title}' and earned {points} points!");
        }
        else
        {
            Console.Write($"\nThe goal '{_title}' is already completed!");
            int input = Program.SelectInput("\n1. Reset the goal\n2. Delete the goal\n3. Do nothing\nWhat would you like to do? ", 1, 3);
            if (input == 1)
            {
                _complete = false;
                Console.WriteLine($"'{_title}' has been reset!");
            }
            else if (input == 2)
            {
                goals.Remove(this);
            }
        }
        return points;
    }

    // Writes to the Stream (for saving)
    public override void WriteStream(StreamWriter writer)
    {
        writer.WriteLine($"Simple,{_title},{_description},{_points},{_complete}");
    }

    // Reads the Stream (for loading)
    public override void ReadStream(string[] attributes)
    {
        _title = attributes[1];
        _description = attributes[2];
        _points = int.Parse(attributes[3]);
        _complete = Boolean.Parse(attributes[4]);
    }
}