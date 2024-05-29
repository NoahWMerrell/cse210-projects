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

    // Creates a scripture from two strings
    public void CreateFromText(string referenceText, string text)
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
        var wordList = new List<string>(text.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        // Creates a list of words
        List<Word> words = wordList.Select(wordText => new Word(wordText)).ToList();

        _reference = reference;
        _words = words;
    }
}