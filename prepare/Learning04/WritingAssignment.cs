public class WritingAssignment : Assignment
{
    // Define variables
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    // Returns homework section and problems as string
    public string GetWritingInformation()
    {
        return ($"{_title} by {_studentName}");
    }
}