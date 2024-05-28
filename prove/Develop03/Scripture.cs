public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Constructor
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
}