using System.ComponentModel.DataAnnotations;

public class Job
{
    // Initialize variables
    public string _nmCompany;
    public string _nmJobTitle;
    public int _nmStartYear;
    public int _nmEndYear;

    // Displays job method
    public void Display()
    {
        Console.WriteLine($"{_nmJobTitle} ({_nmCompany}) {_nmStartYear}-{_nmEndYear}");
    }
}