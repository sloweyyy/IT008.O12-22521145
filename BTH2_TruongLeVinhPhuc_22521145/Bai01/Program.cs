namespace Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap duong dan thu muc: ");
            string? path;
            while (string.IsNullOrEmpty(path = Console.ReadLine()) || !Directory.Exists(path))
            {
                Console.WriteLine("Duong dan khong hop le!");
                Console.WriteLine("Nhap duong dan thu muc: ");
            }

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            Console.WriteLine("Danh sach file: ");
            Console.WriteLine("Thoi gian tao | Loai | Kich thuoc (byte) | Ten");
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine(
                    $"{fileInfo.CreationTime} | {fileInfo.Extension} | {fileInfo.Length} | {fileInfo.Name}");
            }

            Console.WriteLine("Danh sach thu muc: ");
            Console.WriteLine("Thoi gian tao | Ten");
            var directories = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);
                Console.WriteLine($"{directoryInfo.CreationTime} | {directoryInfo.Name}");
            }
        }
    }
}