using System;

class Program
{
    /*
    For creativity I made sure the program ran smoothly and without errors. If the user types in something that isn't in accordance to what the program expects,
    it warns the user and lets them type it in again. Additionally, polymorphism was used with the Simulation class as the parent and the CheckSimulation, Attack Simulation,
    and CombatSimulation as the three children inheriting certain abstract methods and attributes. The Attack class is a child of the Check class and the Character class
    utilizes the Attribute class for the four primary attributes each character has (Might, Agility, Cunning, Influence). The CombatSimulation class successfully runs a
    combat encounter with each Character performing basic attacks against the opposing side.
    */
    static void Main(string[] args)
    {
        MenuLoop();
    }

    // Runs while loop for selecting activity
    public static void MenuLoop()
    {
        int input = 0;
        while (input != 5)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:\n  1. Check Simulation\n  2. Attack Simulation\n  3. Combat Simulation\n  4. Create Character\n  5. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 5);
            if (input == 1)
            {
                // Check Simulation
                Check tempCheck = new Check();
                tempCheck.Set();
                CheckSimulation tempSim = new CheckSimulation(SelectInput("How many millions of iterations would you like to run the simulation (input will be multiplied by 1,000,000)? ", 1, 100)*1000000, tempCheck);
                tempSim.Run();
            }
            else if (input == 2)
            {
                // Attack Simulation
                Attack tempAttack = new Attack();
                tempAttack.Set();
                AttackSimulation tempSim = new AttackSimulation(SelectInput("How many millions of iterations would you like to run the simulation (input will be multiplied by 1,000,000)? ", 1, 100)*1000000, tempAttack);
                tempSim.Run();
            }
            else if (input == 3)
            {
                // Combat Simulation
                CombatSimulation tempSim = new CombatSimulation(SelectInput("How many thousands of iterations would you like to run the simulation (input will be multiplied by 1,000)? ", 1, 100)*1000);
                tempSim.Run();
            }
            else if (input == 4)
            {
                // Create Character and save it to a file
                Character character = new Character();
                character.SaveCharacter();
            }
            else
            {
                // When you select quit
                Console.WriteLine("\nThank you for using the Chronicles Simulation program!");
            }
        }
    }

    // Prompts user to select integer and displays error if it is not one
    public static int SelectInput(string prompt, int low, int high)
    {
        int input = 0;
        Boolean isValid = false;
        while (isValid == false)
        {
            Console.Write(prompt);
            string inputStr = Console.ReadLine();

            // Detect if it isn't an integer and will display error
            if (!int.TryParse(inputStr, out input))
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
                isValid = false;
            }
            else
            {
                input = int.Parse(inputStr);

                // Detect if integer is within specified range
                if (input < low)
                {
                    Console.WriteLine($"Invalid input! Integer is outside of acceptable range. Cannot be less than {low}.");
                    isValid = false;
                }
                else if (input > high)
                {
                    Console.WriteLine($"Invalid input! Integer is outside of acceptable range. Cannot be greater than {high}.");
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
        }
        
        return input;
    }

    // Prompts user to enter a string
    public static string EnterString(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        return input;
    }
}