using System.Dynamic;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Setter
    public void SetReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Getters
    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    // Displays the reference
    public void Display()
    {
        if (_endVerse > 0)
        {
            Console.Write($"{_book} {_chapter}:{_startVerse}-{_endVerse} ");
        }
        else
        {
            Console.Write($"{_book} {_chapter}:{_startVerse} ");
        }
    }
}