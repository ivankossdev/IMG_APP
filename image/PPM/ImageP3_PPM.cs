using System.Text;
namespace img_app;

class ImageP3_PPM : File
{
    readonly RGB_Pixel pixel = new();
    private string _name = "image.ppm";

    public new string Name {
        get => _name;
        set => _name = value + ".ppm";
    }

    public void CreateRandomFile(int width, int height)
    {
        StringBuilder sb = new("P3\n");
        sb.Append($"{width} {height}\n255\n");
        string color = pixel.PixelString();

        int count = 0;

        for (int y = 0; y < height; y++)
        {
            if (count < height / 10)
            { 
                count++;
            }
            else
            {
                color = pixel.PixelString();
                count = 0;
            }

            for (int x = 0; x < width; x++)
            {
                sb.Append(color);
            }

            sb.Append('\n');
        }

        Write(sb.ToString(), Name);
    }
}