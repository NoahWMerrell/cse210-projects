public abstract class Shape
{
    protected string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Gets the contained color attribuite as a string
    public string GetColor()
    {
        return _color;
    }

    // Sets the color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Abstract method for getting the area
    public abstract double GetArea();
}