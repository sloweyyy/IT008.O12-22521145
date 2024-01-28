namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so luong khu dat: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                List<Land> lands = new List<Land>();
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhap loai khu dat thu " + (i + 1) + ": " +
                                      "\n0. Khu dat" +
                                      "\n1. Nha pho" +
                                      "\n2. Chung cu");
                    if (int.TryParse(Console.ReadLine(), out int type) && Enum.IsDefined(typeof(LandType), type))
                    {
                        Land land = CreateLand((LandType)type);
                        lands.Add(land);
                    }
                    else
                    {
                        Console.WriteLine("Loai khu dat khong hop le!");
                        i--;
                    }
                }

                DisplayLandInfo(lands);
                CalculateTotalPrices(lands);
                DisplayLandInfoWithRequiredAreaAndYearBuilt(lands);
                FilterLands(lands);
            }
            else
            {
                Console.WriteLine("So luong khu dat khong hop le!");
            }
        }

        private static Land CreateLand(LandType type)
        {
            Console.WriteLine("Nhap dia diem: ");
            string? location;
            while (string.IsNullOrEmpty(location = Console.ReadLine()))
            {
                Console.WriteLine("Dia diem khong hop le!");
                Console.WriteLine("Nhap dia diem: ");
            }

            Console.WriteLine("Nhap gia ban: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Gia ban khong hop le!");
                Console.WriteLine("Nhap gia ban: ");
            }

            Console.WriteLine("Nhap dien tich: ");
            int area;
            while (!int.TryParse(Console.ReadLine(), out area) || area < 0)
            {
                Console.WriteLine("Dien tich khong hop le!");
                Console.WriteLine("Nhap dien tich: ");
            }

            switch (type)
            {
                case LandType.KhuDat:
                    return new Land(location, price, area);
                case LandType.NhaPho:
                    Console.WriteLine("Nhap nam xay dung: ");
                    int yearBuilt;
                    while (!int.TryParse(Console.ReadLine(), out yearBuilt) || yearBuilt < 0)
                    {
                        Console.WriteLine("Nam xay dung khong hop le!");
                        Console.WriteLine("Nhap nam xay dung: ");
                    }

                    Console.WriteLine("Nhap so tang: ");
                    int numberOfFloors;
                    while (!int.TryParse(Console.ReadLine(), out numberOfFloors) || numberOfFloors < 0)
                    {
                        Console.WriteLine("So tang khong hop le!");
                        Console.WriteLine("Nhap so tang: ");
                    }

                    return new House(location, price, area, yearBuilt, numberOfFloors);
                case LandType.ChungCu:
                    Console.WriteLine("Nhap tang: ");
                    int floor;
                    while (!int.TryParse(Console.ReadLine(), out floor) || floor < 0)
                    {
                        Console.WriteLine("Tang khong hop le!");
                        Console.WriteLine("Nhap tang: ");
                    }

                    return new Apartment(location, price, area, floor);
                default:
                    throw new InvalidOperationException("Loai khu dat khong hop le!");
            }
        }

        private static void DisplayLandInfo(List<Land> lands)
        {
            Console.WriteLine();
            Console.WriteLine("Danh sach cac khu dat, nha pho va chung cu: ");
            foreach (Land land in lands)
            {
                if (land is House)
                    Console.WriteLine("Nha pho: ");
                else if (land is Apartment)
                    Console.WriteLine("Chung cu: ");
                else
                    Console.WriteLine("Khu dat: ");
                Console.WriteLine(land);
            }
        }

        private static void DisplayLandInfoWithRequiredAreaAndYearBuilt(List<Land> lands)
        {
            Console.WriteLine();
            Console.WriteLine("Danh sach cac khu dat co dien tich lon hon 100m2: ");

            foreach (Land land in lands)
            {
                switch (land)
                {
                    case House:
                    case Apartment:
                        continue;
                    default:
                    {
                        if (land.Area > 100)
                        {
                            Console.WriteLine(land);
                        }

                        break;
                    }
                }
            }

            Console.WriteLine("Danh sach cac nha pho co dien tich lon hon 60m2 va nam xay dung sau 2019: ");
            foreach (Land land in lands)
            {
                if (land is House)
                {
                    if (land.Area > 60 && ((House)land).YearBuilt > 2019)
                    {
                        Console.WriteLine(land);
                    }
                }
                else continue;
            }
        }

        private static void CalculateTotalPrices(List<Land> lands)
        {
            int totalLandPrice = 0;
            int totalHousePrice = 0;
            int totalApartmentPrice = 0;
            foreach (Land land in lands)
            {
                if (land is House)
                    totalHousePrice += land.Price;
                else if (land is Apartment)
                    totalApartmentPrice += land.Price;
                else
                    totalLandPrice += land.Price;
            }

            Console.WriteLine("Tong gia ban cac khu dat: " + totalLandPrice);
            Console.WriteLine("Tong gia ban cac nha pho: " + totalHousePrice);
            Console.WriteLine("Tong gia ban cac chung cu: " + totalApartmentPrice);
        }

        private static void FilterLands(List<Land> lands)
        {
            Console.WriteLine();
            Console.WriteLine("Nhap thong tin can tim kiem: ");
            Console.WriteLine("Nhap dia diem: ");
            string? locationSearch;
            while (string.IsNullOrEmpty(locationSearch = Console.ReadLine()))
            {
                Console.WriteLine("Dia diem khong hop le!");
                Console.WriteLine("Nhap dia diem: ");
            }

            Console.WriteLine("Nhap gia ban: ");
            int priceSearch;
            while (!int.TryParse(Console.ReadLine(), out priceSearch) || priceSearch < 0)
            {
                Console.WriteLine("Gia ban khong hop le!");
                Console.WriteLine("Nhap gia ban: ");
            }

            Console.WriteLine("Nhap dien tich: ");
            int areaSearch;
            while (!int.TryParse(Console.ReadLine(), out areaSearch) || areaSearch < 0)
            {
                Console.WriteLine("Dien tich khong hop le!");
                Console.WriteLine("Nhap dien tich: ");
            }

            Console.WriteLine("Danh sach cac nha pho hoac chung cu phu hop: ");
            var matchingHouses = lands.OfType<House>().Where(house =>
                house.Location.Contains(locationSearch) && house.Price <= priceSearch && house.Area >= areaSearch);
            var matchingApartments = lands.OfType<Apartment>().Where(apartment =>
                apartment.Location.Contains(locationSearch) && apartment.Price <= priceSearch &&
                apartment.Area >= areaSearch);

            foreach (var house in matchingHouses)
            {
                Console.WriteLine(house);
            }

            foreach (var apartment in matchingApartments)
            {
                Console.WriteLine(apartment);
            }
        }
    }
}