using System.Text;
using System.IO.Hashing;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        const int w = 82, h = 64;
        Image_BMP image_BMP = new();
        image_BMP.Name = $"image_{w}x{h}";
        image_BMP.CreateBMP(w, h);

        GetFileInfo getFileInfo = new();
        getFileInfo.Name = $"example/image_{w}x{h}.bmp";
        getFileInfo.GetAllByte();
    }
}
