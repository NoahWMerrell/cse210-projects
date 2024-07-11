public class Attribute
{
    // Attributes
    private string _name;
    private int _modifier;

    // Constructor
    public Attribute(string name, int modifier)
    {
        _name = name;
        _modifier = modifier;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public int GetModifier()
    {
        return _modifier;
    }
}