public abstract class Goal
{
    // Attributes
    protected string _title;
    protected string _description;
    protected int _points;

    // Constructors
    public Goal() {}
    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    // Abstract methods
    public abstract Goal CreateGoal();
    public abstract void DisplayGoal();
    public abstract int RecordEvent(List<Goal> goals);
    public abstract void WriteStream(StreamWriter writer);
    public abstract void ReadStream(string[] attributes);

    // Getter for the title
    public string GetTitle()
    {
        return _title;
    }
}