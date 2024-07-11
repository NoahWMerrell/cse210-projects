public class CombatSimulation : Simulation
{
    // Attribute
    private List<Character> _combatants = new List<Character>();

    // Constructor
    public CombatSimulation(int iterations): base(iterations)
    {
        int charNum = Program.SelectInput("How many combatants will there be? ", 2, 20);
        for (int i = 0; i < charNum; i++)
        {
            Console.WriteLine($"----------------------------------\nCombatant #{i+1}\n----------------------------------");
            Character character = new Character();
            _combatants.Add(character);
        }
    }

    public CombatSimulation(int iterations, List<Character> combatants): base(iterations)
    {
        _combatants = combatants;
    }

    public override void Run()
    {
        // Run
    }

    public override void DisplayResults()
    {
        // DisplayResults
    }
}