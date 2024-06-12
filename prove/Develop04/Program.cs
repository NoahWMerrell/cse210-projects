using System;
using System.Reflection;

/*
For the creative portion I did a few things. Firstly, the program checks to make sure when entering in numbers
that they are integers. Second, it will verify the integer is within the specified range, that being 1-5 for
the menu and 10-3600 for the activity durations (the program will inform you if you are outside of these ranges).
Finally, I added another activity called Stretching which guides you through a short arm stretch exercise.
*/
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
        while (input != 5)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Start stretching activity\n  5. Quit");
            input = SelectInput("Select a choice from the menu: ", 1, 5);
            if (input == 1)
            {
                // Breathing activity
                Breathing tempBreathing = new Breathing();
                tempBreathing.RunBreathing();
            }
            else if (input == 2)
            {
                // Reflecting activity
                Reflecting tempReflecting = new Reflecting();
                tempReflecting.RunReflecting();
            }
            else if (input == 3)
            {
                // Listing activity
                Listing tempListing = new Listing();
                tempListing.RunListing();
            }
            else if (input == 4)
            {
                // Stretching activity
                Stretching tempStretching = new Stretching();
                tempStretching.RunStretching();
            }
            else
            {
                // When you select quit
                Console.WriteLine("\nThank you for using the Mindfulness program! You have a wonderful day!");
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