public class Reflecting : Activity
{
    // List of prompts
    private List<string> _prompts = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // List of questions
    private List<string> _questions = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    
    // Constructor
    public Reflecting() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") {}

    // Runs the Reflecting activity
    public void RunReflecting()
    {
        DisplayWelcome();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n --- {Generate(_prompts)} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);

        // Continues to run for duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Console.Clear();
        while (DateTime.Now < endTime)
        {
            Console.Write("\n" + Generate(_questions)+" ");
            Animation(10);
        }
        
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