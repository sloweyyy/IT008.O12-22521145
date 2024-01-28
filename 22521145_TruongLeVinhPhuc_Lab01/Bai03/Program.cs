using System;
using System.Collections.Generic;

namespace Bai03
{
    class Program
    {
        public static void Nhap(int[,] a, int n, int m)
        {
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = random.Next(1, 100);
                }
            }
        }

        public static void Xuat(int[,] a, int n, int m)
        {
            Console.WriteLine($"Ma tran {n}x{m} la:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public static int PhanTuLonNhat(int[,] a, int n, int m)
        {
            int max = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] > max)
                        max = a[i, j];
                }
            }

            return max;
        }

        public static int PhanTuNhoNhat(int[,] a, int n, int m)
        {
            int min = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] < min)
                        min = a[i, j];
                }
            }

            return min;
        }

        public static void DongCoTongLonNhat(int[,] a, int n, int m)
        {
            // tim dong co tong lon nhat
            int max = 0;
            int dong = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += a[i, j];
                }

                if (sum > max)
                {
                    max = sum;
                    dong = i;
                }
            }

            Console.WriteLine($"Dong co tong lon nhat la dong thu {dong + 1}, tong la {max}");
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void TongCacSoKhongPhaiNguyenTo(int[,] a, int n, int m)
        {
            List<int> khongNguyenTo = new List<int>();
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!IsPrime(a[i, j]))
                    {
                        khongNguyenTo.Add(a[i, j]);
                        sum += a[i, j];
                    }
                }
            }

            Console.WriteLine(
                $"Tong cac so khong phai nguyen to la: {sum}, gom cac so: {string.Join(", ", khongNguyenTo)}");
        }

        public static int[,] XoaDongThuK(int[,] a, int n, int m, int k)
        {
            int[,] b = new int[n - 1, m];

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    b[i, j] = a[i, j];
                }
            }

            for (int i = k; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    b[i, j] = a[i + 1, j];
                }
            }

            Console.WriteLine($"Ma tran sau khi xoa dong thu {k + 1} la:");
            Xuat(b, n - 1, m);

            return b;
        }

        public static void XoaCotChuaPhanTuLonNhat(int[,] b, int n, int m)
        {
            int max = 0;
            int cot = 0;
            for (int j = 0; j < m; j++)
            {
                int maxCot = b[0, j];
                for (int i = 0; i < n; i++)
                {
                    if (b[i, j] > maxCot)
                    {
                        maxCot = b[i, j];
                    }
                }

                if (maxCot > max)
                {
                    max = maxCot;
                    cot = j;
                }
            }

            int[,] c = new int[n, m - 1];
            for (int j = 0; j < cot; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    c[i, j] = b[i, j];
                }
            }

            for (int j = cot; j < m - 1; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    c[i, j] = b[i, j + 1];
                }
            }

            Console.WriteLine($"Ma tran sau khi xoa cot chua phan tu lon nhat la:");
            Xuat(c, n, m - 1);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap m: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];

            Nhap(a, n, m);
            Xuat(a, n, m);
            Console.WriteLine();
            Console.WriteLine($"Phan tu lon nhat la: {PhanTuLonNhat(a, n, m)}");
            Console.WriteLine($"Phan tu nho nhat la: {PhanTuNhoNhat(a, n, m)}");
            DongCoTongLonNhat(a, n, m);

            TongCacSoKhongPhaiNguyenTo(a, n, m);
            Console.WriteLine();
            Console.WriteLine("Nhap dong can xoa: ");
            var k = int.Parse(Console.ReadLine());
            int[,] b = XoaDongThuK(a, n, m, k - 1);
            Console.WriteLine();
            XoaCotChuaPhanTuLonNhat(b, n - 1, m);
        }
    }
}