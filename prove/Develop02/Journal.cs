public class Journal
{
    // public string _fileName;
    public List<Entry> _entries = new List<Entry>();

    public Journal() {}

    public static void DisplayEntries(Journal journal)
    {
        foreach (Entry entry in journal._entries)
        {
            Entry.Display(entry);
            Console.WriteLine("");
        }
    }
}