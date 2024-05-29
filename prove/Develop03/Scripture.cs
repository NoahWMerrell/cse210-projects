public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Constructors
    public Scripture() {}
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    // Setter
    public void SetScripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    // Getters
    public Reference GetReference()
    {
        return _reference;
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    // Hides a random Word in the _words list and keeps trying if it is already hidden
    public void HideRandomWord()
    {
        Random random = new Random();
        int randomIndex;
        do
        {
            randomIndex = random.Next(0, _words.Count);
        } while (_words[randomIndex].GetHidden());
        _words[randomIndex].HideWord();
    }

    // Hides a random number of Words in the _words list
    public void HideWords()
    {
        Random random = new Random();
        int iter = random.Next(2,5);
        for (int i = 0; i < iter; i++)
        {
            // Stops loop if all words are hidden
            if (_words.All(w => w.GetHidden()))
            {
                break;
            }
            HideRandomWord();
        }
    }

    // Displays the scripture
    public void Display()
    {
        _reference.Display();
        foreach (Word word in _words)
        {
            word.Display();
            Console.Write(" ");
        }
    }

    // Sets a scripture's Reference and Words from two strings
    public void SetFromText(string referenceText, string wordsText)
    {
        // Goes through each element in referenceText
        var referenceParts = referenceText.Split(' ');
        var book = referenceParts[0];
        var chapter = int.Parse(referenceParts[1]);
        var verses = referenceParts[2].Split('-');
        var verseStart = int.Parse(verses[0]);
        var verseEnd = int.Parse(verses[1]);

        Reference reference = new Reference(book, chapter, verseStart, verseEnd);

        // Split the string into Words
        var wordList = new List<string>(wordsText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        // Creates a list of words
        List<Word> words = wordList.Select(wordText => new Word(wordText)).ToList();

        _reference = reference;
        _words = words;
    }

    // Sets a scripture's Reference and Words from a file
    public void SetFromFile(string filename)
    {
        var lines = File.ReadAllLines(filename);

        // Checks to make sure there are only two lines
        if (lines.Length < 2)
        {
            throw new ArgumentException("The file must contain at least two lines: one for the reference and one for the text.");
        }

        // Reads both lines and Sets the values from the text
        string referenceText = lines[0];
        string wordsText = string.Join(" ", lines.Skip(1));
        SetFromText(referenceText, wordsText);
    }

    // Lets user select file to use for scripture
    public void SelectFromFile()
    {
        Console.Clear();

        // Get input from user
        Console.Write("Type the file name or path of the scripture you'd like to use: ");
        string filename = Console.ReadLine();
        filename = Path.Combine("scriptures", filename);

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist!");
        }
        else
        {
            SetFromFile(filename);
        }
    }

    // Checks if scripture is valid
    public Boolean IsInvalid()
    {
        return _reference == null || _words == null || _words.Count == 0;
    }
}