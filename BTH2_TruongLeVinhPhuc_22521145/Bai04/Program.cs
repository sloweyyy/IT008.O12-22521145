namespace Bai04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so luong gia suc ban dau: ");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                List<Animal> animals = CreateAnimals(n);
                GiaSucKeu(animals);
                GiaSucChoSua(animals);
            }
            else
            {
                Console.WriteLine("So luong gia suc khong hop le!");
            }
        }

        private static List<Animal> CreateAnimals(int n)
        {
            List<Animal> animals = new List<Animal>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap loai gia suc thu {i + 1}: " +
                                  "\n0. Bo" +
                                  "\n1. Cuu" +
                                  "\n2. De");
                if (int.TryParse(Console.ReadLine(), out var type) && Enum.IsDefined(typeof(AnimalType), type))
                {
                    Animal newAnimal = AnimalFactory.CreateAnimal((AnimalType)type);
                    animals.Add(newAnimal);
                }
                else
                {
                    Console.WriteLine("Loai gia suc khong hop le!");
                    i--;
                }
            }

            return animals;
        }

        private static void GiaSucChoSua(List<Animal> animals)
        {
            int totalMilk = 0;
            foreach (Animal animal in animals)
            {
                animal.GiveMilk();
                totalMilk += animal.Milk;
            }

            Console.WriteLine("Tong so luong sua thu duoc: " + totalMilk);
        }

        private static void GiaSucKeu(List<Animal> animals)
        {
            Console.WriteLine("Tieng keu cua cac gia suc: ");
            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}