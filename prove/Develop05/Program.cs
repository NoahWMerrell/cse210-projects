using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        MenuLoop();
    }

    // Runs while loop for selecting activity
    public static void MenuLoop()
    {
        List<Goal> tempGoals = new List<Goal>();
        int points = 0;
        int input = 0;
        while (input != 6)
        {
            Console.WriteLine($"\nYou have {points} points.\n");
            Console.WriteLine("Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 6);
            if (input == 1)
            {
                tempGoals.Add(CreateNewGoal());
            }
            else if (input == 2)
            {
                ListGoals(tempGoals);
            }
            else if (input == 3)
            {
                Console.WriteLine("Save Goals");
            }
            else if (input == 4)
            {
                Console.WriteLine("Load Goals");
            }
            else if (input == 5)
            {
                points += RecordGoals(tempGoals);
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

    // Displays all goals in list
    public static void ListGoals(List<Goal> goals)
    {
        Console.Write("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"\n{i + 1}. ");
            goals[i].DisplayGoal();
        }
    }

    // Lets you record an event for a goal
    public static int RecordGoals(List<Goal> goals)
    {
        Console.Write("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"\n{i + 1}. {goals[i].GetTitle()}");
        }
        int goalIndex = SelectInput("\nWhich goal did you accomplish? ", 1, goals.Count()) - 1;
        return goals[goalIndex].RecordEvent();
    }

    // Lets you create a specific type of goal
    public static Goal CreateNewGoal()
    {
        int input = SelectInput("\nThe type of Goals are:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\nWhich type of goal would you like to create? ", 1, 3);
        Goal tempGoal = null;
        if (input == 1)
        {
            tempGoal = new Simple();
        }
        else if (input == 2)
        {
            tempGoal = new Eternal();
        }
        else
        {
            Console.WriteLine("Checklist goals don't exist yet!");
            tempGoal = new Simple();
        }
        return tempGoal.CreateGoal();
    }
}