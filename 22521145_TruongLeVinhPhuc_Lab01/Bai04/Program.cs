using System;

namespace Bai04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap phan so a: ");
            PhanSo a = new PhanSo();
            a.Nhap();
            Console.WriteLine("Phan so a sau khi rut gon la: ");
            a.RutGon();
            a.Xuat();
            Console.WriteLine("Nhap phan so thu nhat: ");
            PhanSo b = new PhanSo();
            b.Nhap();
            Console.WriteLine("Nhap phan so thu hai: ");
            PhanSo c = new PhanSo();
            c.Nhap();
            Console.WriteLine("Tong hai phan so la: ");
            PhanSo d = b + c;
            d.Xuat();
            Console.WriteLine("Hieu hai phan so la: ");
            d = b - c;
            d.Xuat();
            Console.WriteLine("Tich hai phan so la: ");
            d = b * c;
            d.Xuat();
            Console.WriteLine("Thuong hai phan so la: ");
            d = b / c;
            d.Xuat();
        }
    }
}
