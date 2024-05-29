using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Scripture moroni = new Scripture(
            new Reference("Moroni", 10, 5, 0),
            new List<Word>{
                new Word("And"),
                new Word("by"),
                new Word("the"),
                new Word("power"),
                new Word("of"),
                new Word("the"),
                new Word("Holy"),
                new Word("Ghost"),
                new Word("ye"),
                new Word("may"),
                new Word("know"),
                new Word("the"),
                new Word("truth"),
                new Word("of"),
                new Word("all"),
                new Word("things.")
            });
        // Scripture jacob = new Scripture();
        // jacob.CreateFromText("Jacob 6 12 0","O be wise; what can I say more?");
        ScriptureLoop(moroni);
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