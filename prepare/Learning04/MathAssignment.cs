public class MathAssignment : Assignment
{
    // Define variables
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Returns homework section and problems as string
    public string GetHomeworkList()
    {
        return ($"Section {_textbookSection} Problems {_problems}");
    }
}