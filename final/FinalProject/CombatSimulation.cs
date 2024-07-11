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

    // Runs the simulation
    public override void Run()
    {
        Console.Clear();
        // Roll initiative for each character and sort by highest Initiative >>> Agility >>> Cunning >>> Influence >>> Might >>> Level
        foreach (Character character in _combatants)
        {
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
            Console.Clear();
            Console.WriteLine($"----------------------------------\nRound #{round}\n----------------------------------");

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
                            character.Attack(_combatants[targetIndex], i * 2, false);
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
            foreach (Character character in _combatants)
            {
                character.Status();
            }
            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }
        if (hostilesDefeated)
        {
            Console.WriteLine("Friendlies win!");
        }
        else
        {
            Console.WriteLine("Hostiles win!");
        }
        round++;
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
    }

    // Displays the results of the simulation
    public override void DisplayResults()
    {
        // DisplayResults
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