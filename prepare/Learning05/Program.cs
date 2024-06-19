using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Shape> shapes = new List<Shape>();

        Square square1 = new Square("red", 5);
        shapes.Add(square1);

        Rectangle rectangle1 = new Rectangle("yellow", 5, 3);
        shapes.Add(rectangle1);

        Circle circle1 = new Circle("blue", 3);
        shapes.Add(circle1);

        // Displays the color and area using polymorphism
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}\n");
        }
    }
}