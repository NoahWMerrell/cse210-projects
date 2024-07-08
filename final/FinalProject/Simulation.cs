public abstract class Simulation
{
    // Attributes
    protected int _iterations;

    // Constructors
    public Simulation(int iterations)
    {
        _iterations = iterations;
    }

    // Abstract methods
    public abstract void Run();
    public abstract void DisplayResults();
}