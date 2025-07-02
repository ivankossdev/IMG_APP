using System.Text;
using System.IO.Hashing;
using System.IO.Compression;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        const int w = 640, h = 480;
        ImageBMP image_BMP = new() { Name = $"image_{w}x{h}" };
        image_BMP.Create(w, h);

        Add add = new(image_BMP.Name);
        add.XLines(w);
        add.YLines(h);
        add.AngleLine();

        GetFileInfo getFileInfoBMP = new() { Name = $"example/image_{w}x{h}.bmp" };
        getFileInfoBMP.GetAllByte();

        ImagePNG imagePNG = new() { Name = $"image_{w}x{h}" };
        System.Console.WriteLine(imagePNG.Name);

        // GetFileInfo getFileInfoPng = new() { Name = $"test_ex/ex_2px.png" };
        // getFileInfoPng.GetAllByte();
        GetCRC32("example/image_640x480.txt");
    }
    static void GetCRC32(string path)
    {
        Crc32 crc32 = new();

        using FileStream fs = System.IO.File.Open(path, FileMode.Open);
        // Span<byte> b = [0, 0, 0, 0, 0];
        string hash = string.Empty;
        crc32.Append(fs);
        byte[] checkSum = crc32.GetCurrentHash();
        Array.Reverse(checkSum);
        hash = BitConverter.ToString(checkSum).Replace("-", "").ToLower();
        Console.WriteLine(hash);
    }
}
