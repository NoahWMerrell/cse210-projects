public class Stretching : Activity
{
    // Constructor
    public Stretching() : base("Stretching", "This activity will guide you through a series of stretches to relax your body.") {}

    // Runs the Stretching activity
    public void RunStretching()
    {
        DisplayWelcome();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nStretch your arms up...");
            Countdown(5);
            Console.Write("\nStretch your arms out to the sides...");
            Countdown(5);
            Console.Write("\nStretch down to touch your toes...");
            Countdown(5);
        }
        DisplayEnd();
    }
}