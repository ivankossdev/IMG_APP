using System.Text;

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        string[] folders = ["bmp", "txt"];
        Image_BMP image_BMP = new();

        foreach (string name in folders) {
            if (!image_BMP.CheckFolder(name))
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/{name}/");
        }

        GetFileInfo getInfo = new();
        string[] files = [
            "bmp/i_1x2.bmp",
            "bmp/i_1x3.bmp",
        ];

        foreach (string name in files)
        {
            getInfo.Name = name;
            getInfo.GetAllByte();
        }


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
