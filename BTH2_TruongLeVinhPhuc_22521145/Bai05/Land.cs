namespace Bai05;

class Land
{
    public string Location { get; set; }
    public int Price { get; set; }
    public int Area { get; set; }

    public Land(string location, int price, int area)
    {
        Location = location;
        Price = price;
        Area = area;
    }

    public override string ToString()
    {
        return "Dia diem: " + Location + "\nGia ban: " + Price + "\nDien tich: " + Area;
    }
}