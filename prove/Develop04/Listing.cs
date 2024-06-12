public class Listing : Activity
{
    // List of prompts
    private List<string> _prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    
    // Constructor
    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}

    // Runs the Reflecting activity
    public void RunListing()
    {
        DisplayWelcome();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($" --- {Generate(_prompts)} --- ");
        Console.WriteLine("You may begin in: ");
        Countdown(5);
        int listCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string listedItem = Console.ReadLine();
            if (listedItem.Length > 0)
            {
                listCount++;
            }
        }
        Console.Write($"You listed {listCount} items!");
        DisplayEnd();
    }

    // Randomly selects a string from list
    public static string Generate(List<string> list)
    {
        Random random = new Random();
        int randomIndex = random.Next(0,list.Count);
        return list[randomIndex];
    }
}