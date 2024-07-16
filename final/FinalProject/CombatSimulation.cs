public class CombatSimulation : Simulation
{
    // Attributes
    private List<Character> _combatants = new List<Character>();
    private int _friendlyWins = 0;
    private int _hostileWins = 0;

    // Constructor
    public CombatSimulation(int iterations): base(iterations)
    {
        int charNum = Program.SelectInput("How many combatants will there be? ", 2, 20);
        for (int i = 0; i < charNum; i++)
        {
            Character character;
            Console.WriteLine($"----------------------------------\nCombatant #{i+1}\n----------------------------------");
            int createType = Program.SelectInput("Creation Type:\n  1. Create\n  2. Load\nWould you like to create a new character or load a previously made one? ", 1, 2);
            if (createType == 1)
            {
                character = new Character();
            }
            else
            {
                character = Character.LoadCharacter();
                character.Display();
                Console.Write("You've successfully loaded this character! Press enter to continue: ");
                Console.ReadLine();
            }
            _combatants.Add(character);
        }
    }

    public CombatSimulation(int iterations, List<Character> combatants): base(iterations)
    {
        _combatants = combatants;
    }

    // Runs the simulation
    public override void Run()
    {
        Console.Clear();
        Console.WriteLine("Running simulation...");
        for (int iter = 0; iter < _iterations; iter++)
        {
            // Roll initiative for each character and sort by highest Initiative >>> Agility >>> Cunning >>> Influence >>> Might >>> Level
            foreach (Character character in _combatants)
            {
                character.ResetHP();
                character.RollInitiative();
            }
            _combatants = _combatants.OrderByDescending(p => p.GetInitiative()).ThenByDescending(p => p.GetMod("Agility")).ThenByDescending(p => p.GetMod("Cunning")).ThenByDescending(p => p.GetMod("Influence")).ThenByDescending(p => p.GetMod("Might")).ThenByDescending(p => p.GetMod("Level")).ToList();

            Boolean hostilesDefeated = false;
            Boolean nonHostilesDefeated = false;
            int round = 1;
            while (!hostilesDefeated && !nonHostilesDefeated)
            {
                hostilesDefeated = true;
                nonHostilesDefeated = true;

                // Run each round of combat
                foreach (Character character in _combatants)
                {
                    if (character.GetHP() >= -character.GetProficiency())
                    {
                        int actions = 0;
                        if (character.GetHP() > 0)
                        {
                            actions = 4;
                        }
                        else
                        {
                            actions = 1;
                        }
                        for (int i = 0; i < actions; i++)
                        {
                            int targetIndex = FindTarget(character);
                            if (targetIndex != -1)
                            {
                                character.PerformAttack(_combatants[targetIndex], i * 2);
                            }
                            if (character.GetHostile())
                            {
                                hostilesDefeated = false;
                            }
                            else
                            {
                                nonHostilesDefeated = false;
                            }
                        }
                    }
                }
                round++;
            }
            if (hostilesDefeated)
            {
                _friendlyWins++;

                
            }
            else
            {
                _hostileWins++;
            }
        }
        DisplayResults();
    }

    // Displays the results of the simulation
    public override void DisplayResults()
    {
        Console.WriteLine("Simulation results:");
        double friendlyPercentage = ((double)_friendlyWins / (double)_iterations) * 100;
        double hostilePercentage = ((double)_hostileWins / (double)_iterations) * 100;
        Console.WriteLine($"Friendlies won {friendlyPercentage:F2}% of the time with hostiles winning {hostilePercentage:F2}% of the time.");
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
    }

    // Determines and returns targetIndex to attack
    public int FindTarget(Character character)
    {
        int targetIndex = -1;
        int minHP = int.MaxValue;
        for (int i = 0; i < _combatants.Count(); i++)
        {
            if (_combatants[i].GetHostile() != character.GetHostile() && _combatants[i].GetHP() >= -_combatants[i].GetProficiency())
            {
                if (_combatants[i].GetHP() < minHP)
                {
                    minHP = _combatants[i].GetHP();
                    targetIndex = i;
                }
            }
        }
        return targetIndex;
    }
}