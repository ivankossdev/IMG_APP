using System.Text;
namespace img_app;

class ImageColor_PPM : Image
{
    private string _name = "image.ppm";

    public new string Name {
        get => _name;
        set => _name = value + ".ppm";
    }

    public void CreateRandomFile(int width, int height)
    {
        Random rnd = new();
        StringBuilder sb = new("P3\n");
        sb.Append($"{width} {height}\n255\n");
        string color = $"127 127 127 ";

        int count = 0;

        for (int y = 0; y < height; y++)
        {
            if (count < height / 10)
            { 
                count++;
            }
            else
            {
                color = $"{rnd.Next(0, 255)} {rnd.Next(0, 255)} {rnd.Next(0, 255)} ";
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