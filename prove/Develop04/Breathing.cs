public class Breathing : Activity
{
    // Constructor
    public Breathing() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    // Runs the Breathing activity
    public void RunBreathing()
    {
        DisplayWelcome();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nBreathe in...");
            Countdown(4);
            Console.Write("\nBreathe out...");
            Countdown(6);
        }
        DisplayEnd();
    }
}