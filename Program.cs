using System.Text;
namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        // ImageBW_PBM imagePBM = new("imageBW_84x48");
        // Console.WriteLine(imagePBM.Name);
        // imagePBM.CreateRandomFile(84, 48);

        // ImageBW_PBM imagePBM1 = new("imageBW_1024x768");
        // Console.WriteLine(imagePBM1.Name);
        // imagePBM1.CreateRandomFile(1024, 768);

        ImageColor_PPM color_PPM = new("imageColor_1024x768");
        Console.WriteLine(color_PPM.Name);
        color_PPM.CreateRandomFile(1024, 768);
    }
}
