namespace Bai05;

class House : Land
{
    internal int YearBuilt { get; set;}
    private int NumberOfFloors { get; set; }

    public House(string location, int price, int area, int yearBuilt, int numberOfFloors) : base(location, price,
        area)
    {
        YearBuilt = yearBuilt;
        NumberOfFloors = numberOfFloors;
    }

    public override string ToString()
    {
        return base.ToString() + "\nNam xay dung: " + YearBuilt + "\nSo tang: " + NumberOfFloors;
    }
}