using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Windows.Markup;

/*
For the creative portion I did a few things. First ensured the program would avoid errors by adding a function (SelectInput())
that verifies if the input is an integer and within a specified range. Additionally, I added a feature that when you attempt to
record an event for a Simple or Checklist goal that has already been completed you are given the option to reset it, delete it,
or do nothing. Finally, the user has the option to delete a goal which is needed for deleting eternal goals or if they want to
delete a goal in progress (Note: This won't affect your current point total). For grading purposes, you can load 'goals.txt' or
create your own file to save and load.
*/
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
        while (input != 7)
        {
            Console.WriteLine($"\nYou have {points} points.\n");
            Console.WriteLine("Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Delete Goal\n  7. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 7);
            if (input == 1)
            {
                // When you select Create New Goal
                tempGoals.Add(CreateNewGoal());
            }
            else if (input == 2)
            {
                // When you select List Goals
                ListGoals(tempGoals);
            }
            else if (input == 3)
            {
                // When you select Save Goals
                Save(tempGoals, points);
            }
            else if (input == 4)
            {
                // When you select Load Goals
                points = Load(tempGoals, points);
            }
            else if (input == 5)
            {
                // When you select Record Event
                points += RecordGoals(tempGoals);
            }
            else if (input == 6)
            {
                // When you select Delete Goal
                DeleteGoals(tempGoals);
            }
            else
            {
                // When you select Quit
                Console.WriteLine("\nThank you for using the Eternal Quest program! You have a wonderful day!");
            }
        }
    }

    // Prompts user to select integer and displays error if it is not one or within the specified range
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
            tempGoal = new Checklist();
        }
        return tempGoal.CreateGoal();
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
        return goals[goalIndex].RecordEvent(goals);
    }

    // Lets you delete a goal
    public static void DeleteGoals(List<Goal> goals)
    {
        Console.Write("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"\n{i + 1}. {goals[i].GetTitle()}");
        }
        Console.Write($"\n{goals.Count()+1}. None");
        int goalIndex = SelectInput("\nWhich goal do you want to delete (this will not affect your points)? ", 1, goals.Count()+1) - 1;
        if (goalIndex > 0 && goalIndex < goals.Count())
        {
            goals.RemoveAt(goalIndex);
        }
    }

    // Saves Goals to text file
    public static void Save(List<Goal> goals, int points)
    {
        Console.WriteLine("What would you like to save the filename as?");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(points);
            foreach (Goal goal in goals){
                goal.WriteStream(writer);
            }
        }
    }

    // Reads Goals from text file and loads them into List<Goal>
    public static int Load(List<Goal> goals, int points)
    {
        // Asks for filename to load
        Console.Write("What is the filename to load? ");
        string filename = Console.ReadLine();

        // Determines if file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist!");
            return points;
        }

        // Clears list to avoid duplicating goals
        goals.Clear();

        // Reads each line as each goal with attributes seperated by commas
        using (StreamReader reader = new StreamReader(filename))
        {
            points = int.Parse(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] attributes = line.Split(',');
                string type = attributes[0];
                Goal goal;
                if (type == "Simple")
                {
                    goal = new Simple();
                }
                else if (type == "Eternal")
                {
                    goal = new Eternal();
                }
                else if (type == "Checklist")
                {
                    goal = new Checklist();
                }
                else
                {
                    throw new InvalidOperationException("Goal type unknown");
                }
                goal.ReadStream(attributes);
                goals.Add(goal);
            }
        }
        // Alerts user of completion
        Console.WriteLine($"'{filename}' successfully loaded!");
        return points;
    }
}