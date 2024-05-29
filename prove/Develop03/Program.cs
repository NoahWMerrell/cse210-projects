using System;
using System.Runtime.InteropServices;


/*
For the creative portion I had the program ask the user for a filename and it automatically will read the information in the file
(assuming proper formatting of it) and use that scripture for the scripture memorizer. These scriptures are included in the
"scriptures" folder and it is the default directory, meaning the program will always look for files in that folder
(and there's no need to add "scriptures/" to the filename). For testing purposes you can just type "template.txt" to see.
*/
class Program
{
    static void Main(string[] args)
    {
        Scripture tempScripture = new Scripture();
        tempScripture.SelectFromFile();
        if (tempScripture.IsInvalid())
        {
            Console.WriteLine("Scripture is invalid. Exiting program.");
        }
        else
        {
            ScriptureLoop(tempScripture);
        }
    }

    public static void ScriptureLoop(Scripture tempScripture)
    {
        string input = "";
        Boolean isAllHidden = false;
        // Will continue running until user types 'quit' or all words are hidden
        while ((input.ToLower() != "quit") && (!isAllHidden))
        {
            Console.Clear();
            tempScripture.Display();

            // Get input from user
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish:");
            input = Console.ReadLine();

            tempScripture.HideWords();

            // Boolean that updates when all words _hidden value is true
            isAllHidden = tempScripture.GetWords().All(w => w.GetHidden());
        }

        // Displays one final time if all words are hidden and informs them of it
        if (isAllHidden)
        {
            Console.Clear();
            tempScripture.Display();
            Console.WriteLine("\n\nAll words are hidden.");
        }
    }
}