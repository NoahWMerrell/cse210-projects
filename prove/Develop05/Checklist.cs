public class Checklist : Goal
{
    // Attributes
    private int _count;
    private int _maxCount;
    private int _bonusPoints;
    
    // Constructors
    public Checklist() {}
    public Checklist(string title, string description, int points, int maxCount, int bonusPoints): base(title, description, points)
    {
        _count = 0;
        _maxCount = maxCount;
        _bonusPoints = bonusPoints;
    }

    // Creates the goal
    public override Checklist CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = Program.SelectInput("What is the amount of points associated with this goal? ", 0, 100000);
        int maxCount = Program.SelectInput("How many times does this goal need to be accomplished for a bonus? ", 1, 365);
        int bonusPoints = Program.SelectInput($"What is the bonus for accomplishing it {maxCount} times? ", 0, 100000);
        return new Checklist(title, description, points, maxCount, bonusPoints);
    }
    
    // Displays the goal
    public override void DisplayGoal()
    {
        if (_count != _maxCount)
        {
            Console.Write("[ ]");
        }
        else
        {
            Console.Write("[X]");
        }
        Console.Write($" {_title} ({_description}) -- Currently Completed {_count}/{_maxCount}");
    }

    // Record an event
    public override int RecordEvent(List<Goal> goals)
    {
        int points = 0;
        if (_count != _maxCount)
        {
            _count++;
            points = _points;
            Console.WriteLine($"You made progress for '{_title}' and earned {points} points!");
            if (_count == _maxCount)
            {
                points += _bonusPoints;
                Console.WriteLine($"You finished '{_title}' and earned {_bonusPoints} bonus points!");
            }
        }
        else
        {
            Console.WriteLine($"The goal '{_title}' is already completed!");
            int input = Program.SelectInput("\n1. Reset the goal\n2. Delete the goal\n3. Do nothing\nWhat would you like to do? ", 1, 3);
            if (input == 1)
            {
                _count = 0;
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
        writer.WriteLine($"Checklist,{_title},{_description},{_points},{_count},{_maxCount},{_bonusPoints}");
    }

    // Reads the Stream (for loading)
    public override void ReadStream(string[] attributes)
    {
        _title = attributes[1];
        _description = attributes[2];
        _points = int.Parse(attributes[3]);
        _count = int.Parse(attributes[4]);
        _maxCount = int.Parse(attributes[5]);
        _bonusPoints = int.Parse(attributes[6]);
    }
}