using System;

namespace Bai02
{
    class Program
    {
        static int TongLe(int[] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0)
                    tong += a[i];
            }

            return tong;
        }

        static bool IsNguyenTo(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int SoSoNguyenTo(int[] a, int n)
        {
            int dem = 0;
            for (int i = 0; i < n; i++)
            {
                if (IsNguyenTo(a[i]))
                    dem++;
            }

            return dem;
        }

        static int SoChinhPhuongNhoNhat(int[] a, int n)
        {
            int soChinhPhuongNhoNhat = -1;
            for (int i = 0; i < n; i++)
            {
                double sqrt = Math.Sqrt(a[i]);
                if (sqrt == (int)sqrt)
                {
                    soChinhPhuongNhoNhat = a[i];
                    break;
                }
            }

            return soChinhPhuongNhoNhat;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Console.WriteLine("Mang: ");
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1, 100);
                Console.WriteLine("a[{0}] = {1}", i, a[i]);
            }

            Console.WriteLine("Tong cac so le trong mang: {0}", TongLe(a, n));
            Console.WriteLine("So so nguyen to trong mang: {0}", SoSoNguyenTo(a, n));
            Console.WriteLine("So chinh phuong nho nhat trong mang: {0}", SoChinhPhuongNhoNhat(a, n));
        }
    }
}