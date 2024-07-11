public class CheckSimulation : Simulation
{
    // Attributes
    private Check _check;
    private Dictionary<int, int> _results;
    
    // Constructors
    public CheckSimulation(int iterations, Check check): base(iterations)
    {
        _check = check;
        _results = new Dictionary<int, int>();
    }

    public override void Run()
    {
        Console.WriteLine("Running simulation...");
        for (int i = 0; i < _iterations; i++)
        {
            int result = _check.Roll();
            if (_results.ContainsKey(result))
            {
                _results[result]++;
            }
            else
            {
                _results[result] = 1;
            }
        }
        DisplayResults();
    }

    public override void DisplayResults()
    {
        Console.WriteLine("Simulation results:");
        double sum = 0;
        foreach (var result in _results.OrderBy(r => r.Key))
        {
            double percentage = (double)result.Value / _iterations * 100;
            int barCount = (int)(percentage / 0.2);
            string bar = new string('█', barCount);
            Console.WriteLine($"{result.Key,2}: {bar} {percentage:F2}%");
            sum += result.Key * result.Value;
        }
        double average = sum / _iterations;
        Console.WriteLine($"Average Total: {average:F2}");
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
    }
}