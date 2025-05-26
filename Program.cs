using System.Text;
using System.IO.Hashing;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        Image_BMP image_BMP = new();
        image_BMP.Name = "image_82x64";
        image_BMP.CreateBMP(82, 64);
        
        GetFileInfo getFileInfo = new();
        getFileInfo.Name = "example/image_82x64.bmp";
        getFileInfo.GetAllByte();
    }

    static void CreateImage()
    {
        ImageP1_PBM bw_PBM = new();
        ImageP3_PPM color_PPM = new();
        ImageP5_PGM bw_PGM = new();

        for (int i = 0; i < 4; i++)
        {
            bw_PBM.Name = $"image_bw_1024x768_{i}";
            bw_PBM.CreateRandomFile(1024, 768);

            bw_PGM.Name = $"image_bwg_1024x768_{i}";
            bw_PGM.CreateRandomFile(1024, 768);

            color_PPM.Name = $"image_color_1024x768_{i}";
            color_PPM.CreateRandomFile(1024, 768);
        }
    }
}
