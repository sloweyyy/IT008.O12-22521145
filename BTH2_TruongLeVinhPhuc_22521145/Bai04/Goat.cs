namespace Bai04;

class Goat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("De: me me me");
    }

    public override void GiveMilk()
    {
        var random = new Random();
        Milk = random.Next(0, 10);
        Console.WriteLine("De: Cho " + Milk + " lit sua");
    }
}