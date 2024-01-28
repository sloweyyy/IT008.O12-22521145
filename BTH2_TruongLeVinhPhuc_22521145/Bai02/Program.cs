namespace Bai02
{
    class Program
    {
        static void ChuanHoa(ref string hoTen)
        {
            hoTen = hoTen.Trim();
            while (hoTen.IndexOf("  ", StringComparison.Ordinal) != -1)
            {
                hoTen = hoTen.Replace("  ", " ");
            }

            hoTen = hoTen.ToLower();
            string[] arr = hoTen.Split(' ');
            hoTen = "";
            for (int i = 0; i < arr.Length; i++)
            {
                hoTen += char.ToUpper(arr[i][0]) + arr[i].Substring(1);
                if (i < arr.Length - 1)
                {
                    hoTen += " ";
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap chuoi ho ten: ");
            string? hoTen;
            while (string.IsNullOrEmpty(hoTen = Console.ReadLine()))
            {
                Console.WriteLine("Ho ten khong hop le!");
                Console.WriteLine("Nhap chuoi ho ten: ");
            }

            ChuanHoa(ref hoTen);
            Console.WriteLine("Ho ten sau khi chuan hoa: " + hoTen);
        }
    }
}