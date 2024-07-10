using System;

class Program
{
    static void Main(string[] args)
    {
        MenuLoop();
    }

    // Runs while loop for selecting activity
    public static void MenuLoop()
    {
        int input = 0;
        while (input != 3)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:\n  1. Check Simulation\n  2. Attack Simulation\n  3. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 3);
            if (input == 1)
            {
                // Check Simulation
                Check tempCheck = new Check();
                CheckSimulation tempSim = new CheckSimulation(SelectInput("How many millions of iterations would you like to run the simulation (input will be multiplied by 1,000,000)? ", 1, 100)*1000000, tempCheck);
                tempSim.Run();
                Console.Write("Press enter to continue: ");
                Console.ReadLine();
            }
            else if (input == 2)
            {
                // Attack Simulation
                Attack tempAttack = new Attack();
                Console.WriteLine($"Damage: {tempAttack.Damage()}");
                Console.Write("Press enter to continue: ");
                Console.ReadLine();
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
                Console.WriteLine("Invalid input! Please enter an integer.\n");
                isValid = false;
            }
            else
            {
                input = int.Parse(inputStr);

                // Detect if integer is within specified range
                if (input < low)
                {
                    Console.WriteLine($"Invalid input! Integer is outside of acceptable range. Cannot be less than {low}.\n");
                    isValid = false;
                }
                else if (input > high)
                {
                    Console.WriteLine($"Invalid input! Integer is outside of acceptable range. Cannot be greater than {high}.\n");
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
}