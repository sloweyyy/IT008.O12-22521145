namespace Bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap chieu dai: ");
            var width = Console.ReadLine();
            if (float.TryParse(width, out var w))
            {
                Console.WriteLine("Nhap chieu rong: ");
                var height = Console.ReadLine();
                if (float.TryParse(height, out var h))
                {
                    var rectangle = new Rectangle(w, h);
                    rectangle.CalculateArea();
                    rectangle.CalculatePerimeter();
                }
                else
                {
                    Console.WriteLine("Chieu rong khong hop le!");
                }
            }
            else
            {
                Console.WriteLine("Chieu dai khong hop le!");
            }
        }
    }
}