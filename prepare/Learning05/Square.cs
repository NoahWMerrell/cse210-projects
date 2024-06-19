public class Square : Shape
{
    private double _side;
    
    // Constructor
    public Square(string color, double side): base(color)
    {
        _side = side;
    }

    // Returns the area of the square
    public override double GetArea()
    {
        return _side * _side;
    }
}