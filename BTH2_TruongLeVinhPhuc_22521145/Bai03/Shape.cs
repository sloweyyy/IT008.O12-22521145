namespace Bai03;

abstract class Shape
{
    protected abstract float Area();
    protected abstract float Perimeter();

    public virtual void CalculateArea()
    {
        Console.WriteLine("Dien tich: " + Area());
    }

    public virtual void CalculatePerimeter()
    {
        Console.WriteLine("Chu vi: " + Perimeter());
    }
}