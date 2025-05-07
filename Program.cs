namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        ImageP1_PBM bw_PBM = new();
        ImageP3_PPM color_PPM = new();
        ImageP5_PGM bw_PGM = new();

        for(int i = 0; i < 4; i++){
            bw_PBM.Name = $"image_bw_1024x768_{i}";
            bw_PBM.CreateRandomFile(1024, 768);

            bw_PGM.Name = $"image_bwg_1024x768_{i}";
            bw_PGM.CreateRandomFile(1024, 768);

            color_PPM.Name = $"image_color_1024x768_{i}";
            color_PPM.CreateRandomFile(1024, 768);
        }

        GetFileInfo getInfo = new(){
            Name = "image_4x4.bmp"
        };
        getInfo.GetAllByte();
    }
}
