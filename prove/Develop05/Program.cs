using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        MenuLoop();
    }

    // Runs while loop for selecting activity
    public static void MenuLoop()
    {
        List<Goal> tempGoals = new List<Goal>();
        int input = 0;
        while (input != 6)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 6);
            if (input == 1)
            {
                Simple tempSimple = new Simple();
                tempSimple = tempSimple.CreateGoal();
                tempSimple.DisplayGoal();
                tempGoals.Add(tempSimple);
                Thread.Sleep(5000);
            }
            else if (input == 2)
            {
                Console.WriteLine("List Goals");
                Thread.Sleep(3000);
            }
            else if (input == 3)
            {
                Console.WriteLine("Save Goals");
                Thread.Sleep(3000);
            }
            else if (input == 4)
            {
                Console.WriteLine("Load Goals");
                Thread.Sleep(3000);
            }
            else if (input == 5)
            {
                Console.WriteLine("Record Event");
                Thread.Sleep(3000);
            }
            else
            {
                // When you select quit
                Console.WriteLine("\nThank you for using the Eternal Quest program! You have a wonderful day!");
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