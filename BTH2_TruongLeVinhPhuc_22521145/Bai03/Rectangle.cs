namespace Bai03;

class Rectangle : Shape
{
    private float _width;
    private float _height;

    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
    }

    protected override float Area()
    {
        return _width * _height;
    }

    protected override float Perimeter()
    {
        return (_width + _height) * 2;
    }

    public override void CalculateArea()
    {
        Console.WriteLine("Dien tich: " + Area());
    }

    public override void CalculatePerimeter()
    {
        Console.WriteLine("Chu vi: " + Perimeter());
    }
}