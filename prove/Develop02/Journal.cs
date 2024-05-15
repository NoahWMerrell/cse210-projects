public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Journal constructor
    public Journal() {}

    // Displays all entries from Journal
    public static void Display(Journal journal)
    {
        foreach (Entry entry in journal._entries)
        {
            Entry.Display(entry);
            Console.WriteLine("");
        }
    }

    // Saves Journal to text file
    public static void Save(Journal journal)
    {
        Console.WriteLine("What would you like to save the filename as (Include '.txt')?");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in journal._entries){
                writer.WriteLine(entry._dateTime);
                writer.WriteLine(entry._prompt);
                writer.WriteLine(entry._input);
            }
        }
    }

    // Reads entries from text file and loads them into Journal
    public static Journal Load(Journal journal)
    {
        // Asks for filename to load
        Console.WriteLine("What is the filename to load (Include '.txt')?");
        string filename = Console.ReadLine();

        // Determines if file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist!");
            return journal;
        }

        // Reads each line for each part of the Entry and adds each Entry to the Journal
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                // Identifies each attribute of the Entry
                DateTime dateTime = DateTime.Parse(reader.ReadLine());
                string prompt = reader.ReadLine();
                string input = reader.ReadLine();

                // Creates new Entry and adds it into journal
                Entry entry = new Entry(dateTime, input, prompt);
                journal._entries.Add(entry);
            }
        }
        // Alerts user of completion
        Console.WriteLine($"'{filename}' successfully loaded!");
        return journal;
    }
}