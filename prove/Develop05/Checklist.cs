public class Checklist : Goal
{
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
    public override int RecordEvent()
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
        }
        return points;
    }
}