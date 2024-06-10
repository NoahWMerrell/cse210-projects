using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity("Test", "An activity for testing purposes.");
        MenuLoop();
        activity.DisplayWelcome();
    }

    // Runs while loop for selecting activity
    public static void MenuLoop()
    {
        int input = 0;
        while (input != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Quit");
            input = SelectInput("Select a choice from the menu: ");
        }
    }

    // Prompts user to select integer and displays error if it is not one
    public static int SelectInput(string prompt)
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
                isValid = true;
            }
        }
        
        return input;
    }
}