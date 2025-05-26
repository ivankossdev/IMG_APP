using System.Text;
using System.IO.Hashing;
// dotnet add package System.IO.Hashing

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        string[] folders = ["bmp", "txt"];
        Image_BMP image_BMP = new();
        // for (int i = 1; i <= 5; i++)
        // {
        //     image_BMP.CreateBMP(i, 1);
        // }

        // foreach (string name in folders)
        // {
        //     if (!image_BMP.CheckFolder(name))
        //         Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/{name}/");
        // }

        // GetFileInfo getInfo = new();
        // string[] files = [
        //     "bmp/i_1x1.bmp",
        //     "bmp/i_1x2.bmp",
        //     "bmp/i_1x3.bmp",
        //     "bmp/i_2x1.bmp",
        //     "bmp/i_3x1.bmp",
        //     "bmp/i_4x1.bmp",
        //     "bmp/i_5x1.bmp",
        //     "bmp/i_82x64.bmp",
        //     "bmp/i_600x400.bmp"
        // ];

        // foreach (string name in files)
        // {
        //     getInfo.Name = name;
        //     getInfo.GetAllByte();
        // }
        image_BMP.CreateBMP(3, 1);
        // image_BMP.CreateBMP(82, 64);
        // image_BMP.CreateBMP(600, 400);
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
