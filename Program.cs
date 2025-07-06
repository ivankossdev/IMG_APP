using System.Text;
using System.IO.Hashing;
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

        GetFileInfo getFileInfoPng = new() { Name = $"test_ex/ex_2px.png" };
        getFileInfoPng.GetAllByte();

        string hash = HashHandler.GetCRC32(new Crc32(), "example/image_640x480.txt");
        System.Console.WriteLine(hash);
        hash = HashHandler.GetCRC32(new Crc32(), [0x00, 0x01, 0x0f]);
        System.Console.WriteLine(hash);
    }
}
