using System.Text;
using System.IO.Hashing;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        const int w = 82, h = 64;
        Image_BMP image_BMP = new()
        {
            Name = $"image_{w}x{h}"
        };

        image_BMP.Create(w, h);

        Editor editor = new()
        {
            Name = image_BMP.Name
        };

        editor.AddLine();

        GetFileInfo getFileInfo = new()
        {
            Name = $"example/image_{w}x{h}.bmp"
        };
        getFileInfo.GetAllByte();
    }
}
