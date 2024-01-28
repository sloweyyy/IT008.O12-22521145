namespace Bai04;

class PhanSo
{
    private int tuSo;
    private int mauSo;

    public PhanSo()
    {
        tuSo = 0;
        mauSo = 1;
    }

    public PhanSo(int tuSo, int mauSo)
    {
        this.tuSo = tuSo;
        this.mauSo = mauSo;
    }

    public void Nhap()
    {
        while (true)
        {
            Console.WriteLine("Nhap tu so: ");
            tuSo = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mau so: ");
            mauSo = int.Parse(Console.ReadLine());
            if (mauSo == 0)
                Console.WriteLine("Mau so phai khac 0. Vui long nhap lai!");
            else
                break;
        }
    }

    public void Xuat()
    {
        Console.WriteLine("{0}/{1}", tuSo, mauSo);
    }

    public int UCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (a != b)
        {
            if (a > b)
                a -= b;
            else
                b -= a;
        }

        return a;
    }

    public void RutGon()
    {
        int ucln = UCLN(tuSo, mauSo);
        tuSo /= ucln;
        mauSo /= ucln;
    }

    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        PhanSo c = new PhanSo();
        c.tuSo = a.tuSo * b.mauSo + b.tuSo * a.mauSo;
        c.mauSo = a.mauSo * b.mauSo;
        c.RutGon();
        return c;
    }

    public static PhanSo operator -(PhanSo a, PhanSo b)
    {
        PhanSo c = new PhanSo();
        c.tuSo = a.tuSo * b.mauSo - b.tuSo * a.mauSo;
        c.mauSo = a.mauSo * b.mauSo;
        c.RutGon();
        return c;
    }

    public static PhanSo operator *(PhanSo a, PhanSo b)
    {
        PhanSo c = new PhanSo();
        c.tuSo = a.tuSo * b.tuSo;
        c.mauSo = a.mauSo * b.mauSo;
        c.RutGon();
        return c;
    }

    public static PhanSo operator /(PhanSo a, PhanSo b)
    {
        PhanSo c = new PhanSo();
        c.tuSo = a.tuSo * b.mauSo;
        c.mauSo = a.mauSo * b.tuSo;
        c.RutGon();
        return c;
    }
}