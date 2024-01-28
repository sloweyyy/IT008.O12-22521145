namespace Bai05;

class Apartment : Land
{
    private int Floor { get; set; }

    public Apartment(string location, int price, int area, int floor) : base(location, price, area)
    {
        Floor = floor;
    }

    public override string ToString()
    {
        return base.ToString() + "\nTang: " + Floor;
    }
}