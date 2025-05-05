using System.Text;
namespace img_app;

class ImageColor_PPM(string fileName) : Image(fileName)
{
    private readonly string _name = fileName + ".ppm";

    public new string Name => _name;
    public void CreateRandomFile(int width, int height)
    {
        Random rnd = new();
        StringBuilder sb = new("P3\n");
        sb.Append($"{width} {height}\n255\n");
        string color = $"127 127 127 ";

        int count = 0;

        for (int y = 0; y < height; y++)
        {
            if (count < 32)
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