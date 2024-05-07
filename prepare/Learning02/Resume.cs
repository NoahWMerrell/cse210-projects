using System.ComponentModel.DataAnnotations;
public class Resume
{
    // Initialize variables
    public string _nmName;
    public List<Job> _nmJobs = new List<Job>();

    // Displays resume method
    public void Display()
    {
        Console.WriteLine($"Name: {_nmName}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _nmJobs)
        {
            job.Display();
        }
    }
}