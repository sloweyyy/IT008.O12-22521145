namespace Bai04;

class Cow : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bo: umbo umbo");
    }

    public override void GiveMilk()
    {
        var random = new Random();
        Milk = random.Next(0, 20);
        Console.WriteLine("Bo: Cho " + Milk + " lit sua");
    }
}