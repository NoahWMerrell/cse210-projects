public class AttackSimulation : Simulation
{
    // Atribute
    private Attack _attack;
    private Dictionary<int, int> _results;
    
    // Constructors
    public AttackSimulation(int iterations, Attack attack): base(iterations)
    {
        _attack = attack;
        _results = new Dictionary<int, int>();
    }

    // Runs the simulation
    public override void Run()
    {
        Console.WriteLine("Running simulation...");
        for (int i = 0; i < _iterations; i++)
        {
            int result = _attack.Damage();
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

    // Runs the simulation
    public override void DisplayResults()
    {
        Console.WriteLine("Simulation results:");
        double sum = 0;
        int count = _results.Count;
        foreach (var result in _results.OrderBy(r => r.Key))
        {
            double percentage = (double)result.Value / _iterations * 100;
            int barCount = (int)(percentage / 1);
            string bar = new string('█', barCount);
            Console.WriteLine($"{result.Key,2}: {bar} {percentage:F2}%");
            sum += result.Key * result.Value;
        }
        double average = sum / _iterations;
        Console.WriteLine($"Average Damage: {average:F2}");
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
    }
}