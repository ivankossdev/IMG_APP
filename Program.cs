using System.Text;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        const int w = 2, h = 2;

        // ImageBMP image_BMP = new() { Name = $"image_{w}x{h}" };
        // image_BMP.Create(w, h);

        // DrawBMP draw = new(image_BMP.Name);
        // draw.XLines(w);
        // draw.YLines(h);
        // draw.AngleLine();
        // draw.AngleLine(10);

        // GetFileInfo getFileInfoBMP = new() { Name = $"example/image_{w}x{h}.bmp" };
        // getFileInfoBMP.GetAllByte();

        GetFileInfo getFileInfoPng = new() { Name = $"test_ex/ex_2px.png" };
        getFileInfoPng.GetAllByte();

        ImagePNG imagePNG = new() { Name = $"image_{w}x{h}" };
        imagePNG.Create(w, h);

        GetFileInfo getFileInfoPng1 = new() { Name = $"example/image_{w}x{h}.png" };
        getFileInfoPng1.GetAllByte();
    }
}
