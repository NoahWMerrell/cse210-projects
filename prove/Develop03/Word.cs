public class Word {
    private string _word;
    private Boolean _hidden;

    // Constructor
    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    // Setters
    public string SetWord(string word)
    {
        return word;
    }

    public void HideWord()
    {
        _hidden = true;
    }

    // Getters
    public string GetString()
    {
        return _word;
    }
    public Boolean GetHidden()
    {
        return _hidden;
    }

    // Displays the word unless it is hidden (which will be replaced with underscores)
    public void Display()
    {
        if (_hidden == false)
        {
            Console.Write(_word);
        }
        else
        {
            // Writes underscore for each character
            for (int i = 0; i < _word.Length; i++)
            {
                Console.Write("_");
            }
        }
    }
}