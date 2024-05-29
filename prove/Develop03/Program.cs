using System;
using System.Runtime.InteropServices;

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