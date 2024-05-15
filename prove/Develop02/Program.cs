using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    // public static Journal currentJournal;
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        MenuLoop();
    }

    // Menu that is looped for program
    static void MenuLoop(){
        Journal tempJournal = new Journal();
        int option = 0;
        // Loop will only stop if 5 is inputted
        while (option != 5) {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");

            // Receive input from user
            Console.Write("What would you like to do? ");
            string optionStr = Console.ReadLine();

            // Detect if it isn't an integer and will display error
            if (!int.TryParse(optionStr, out option))
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
                continue;
            }
            option = int.Parse(optionStr);

            // Write an entry for tempJournal
            if (option == 1)
            {
                tempJournal._entries.Add(Entry.Create());
            }
            // Display all entries in tempJournal
            else if (option == 2)
            {
                Journal.Display(tempJournal);
            }
            // Load entries from text file
            else if (option == 3)
            {
                Journal.Load(tempJournal);
            }
            // Save entries to text file
            else if (option == 4)
            {
                Journal.Save(tempJournal);
            }
            // Display error if input is not valid
            else
            {
                if (option != 5)
                {
                    Console.WriteLine("Invalid input! Please enter a valid option.");
                }
            }
        }
    }
}