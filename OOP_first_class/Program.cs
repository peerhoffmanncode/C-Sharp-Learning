var rectangle1 = new Rectangle(5, 10);

var rectangle2 = new Rectangle(15, 20);

var rectangle3 = new Rectangle(25, 30);

// rectangle

rectangle1.ShowDimensions();
Console.WriteLine("Circumference: " + rectangle1.CalculateCircumference() + " Area: " + rectangle1.CalculateArea());
rectangle2.ShowDimensions();
Console.WriteLine("Circumference: " + rectangle2.CalculateCircumference() + " Area: " + rectangle2.CalculateArea());
rectangle3.ShowDimensions();
Console.WriteLine("Circumference: " + rectangle3.CalculateCircumference() + " Area: " + rectangle3.CalculateArea());

Console.ReadKey();


class Rectangle
{
    public int Width;
    public int Height;

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void ShowDimensions()
    {
        Console.WriteLine("Width is " + Width + " and Height is " + Height);
    }

    public int CalculateCircumference()
    {
        return 2 * (Width + Height);
    }

    public int CalculateArea()
    {
        return Width * Height;
    }
}




