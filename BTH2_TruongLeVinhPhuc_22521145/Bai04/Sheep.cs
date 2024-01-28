namespace Bai04;

class Sheep : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cuu: be be be");
    }

    public override void GiveMilk()
    {
        var random = new Random();
        Milk = random.Next(0, 5);
        Console.WriteLine("Cuu: Cho " + Milk + " lit sua");
    }
}