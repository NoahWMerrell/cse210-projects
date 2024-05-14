using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    // public static Journal currentJournal;
    static void Main(string[] args)
    {
        Entry newEntry = Entry.Create("I had a wonderful day!");
        Entry.Display(newEntry);

        string filePath = "data.txt";
        SaveJournal(filePath, "Hello world!");

        string data = LoadJournal(filePath);
        Console.WriteLine($"Text read from {filePath}: {data}");
    }

    // Saves Journal to text file
    static void SaveJournal(string filePath, string data)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(data);
        }
    }

    // Returns string of information contained in text file
    static string LoadJournal(string filePath)
    {
        string data = "";
        using (StreamReader reader = new StreamReader(filePath))
        {
            data = reader.ReadToEnd();
        }
        return data;
    }
}