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

        Editor editor = new(image_BMP.Name);
        editor.RandomPixels();
        editor.Lines(100);
        
        GetFileInfo getFileInfo = new() { Name = $"example/image_{w}x{h}.bmp" };
        getFileInfo.GetAllByte();
        // getFileInfo.Name = $"example/image_{w}x{h}_Rand.bmp";
        // getFileInfo.GetAllByte();
    }
}
