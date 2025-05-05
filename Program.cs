using System.Text;
namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        ImageP1_PBM bw_PBM = new();
        ImageP3_PPM color_PPM = new();
        for(int i = 0; i < 2; i++){
            color_PPM.Name = $"image_color_1024x768_{i}";
            color_PPM.CreateRandomFile(1024, 768);
            bw_PBM.Name = $"image_bw_1024x768_{i}";
            bw_PBM.CreateRandomFile(1024, 768);
        }
    }
}
