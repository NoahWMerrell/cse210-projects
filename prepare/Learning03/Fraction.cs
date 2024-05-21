public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters
    
    // Return the top value
    public int GetTop()
    {
        return _top;
    }
    // Return the bottom value
    public int GetBottom()
    {
        return _bottom;
    }
    // Return the fraction as a string
    public string GetFractionString()
    {
        return ($"{_top}/{_bottom}");
    }
    // Return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return ((double)_top/(double)_bottom);
    }

    // Setters

    // Set the top value
    public void SetTop(int top)
    {
        _top = top;
    }
    // Set the bottom value
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
}