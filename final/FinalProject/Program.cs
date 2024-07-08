using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Check check = new Check(0, 2, 0);
        CheckSimulation sim = new CheckSimulation(1000000, check);
        sim.Run();
    }
}