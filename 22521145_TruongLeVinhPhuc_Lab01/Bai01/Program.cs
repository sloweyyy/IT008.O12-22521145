using System;

namespace Bai01
{
    class Program
    {
        static int SoNgay(int thang, int nam)
        {
            DateTime firstDayOfMonth = new DateTime(nam, thang, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            int ngay = (firstDayOfNextMonth - firstDayOfMonth).Days;

            return ngay;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap thang: ");
            int thang = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nam: ");
            int nam = int.Parse(Console.ReadLine());

            int soNgay = SoNgay(thang, nam);

            if (soNgay > 0)
                Console.WriteLine($"So ngay cua thang {thang} nam {nam} la: {soNgay} ngay");
            else
                Console.WriteLine("Thang khong hop le.");
        }
    }
}