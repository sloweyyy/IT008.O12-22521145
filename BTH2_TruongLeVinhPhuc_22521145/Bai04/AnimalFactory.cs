namespace Bai04;

public static class AnimalFactory
{
    public static Animal CreateAnimal(AnimalType type)
    {
        return type switch
        {
            AnimalType.Bo => new Cow(),
            AnimalType.Cuu => new Sheep(),
            AnimalType.De => new Goat(),
            _ => throw new ArgumentException("Loai gia suc khong hop le!"),
        };
    }
}