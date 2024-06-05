public class Assignment
{
    // Define variables
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Returns a summary in the form of a string
    public string GetSummary()
    {
        return ($"{_studentName} - {_topic}");
    }
}