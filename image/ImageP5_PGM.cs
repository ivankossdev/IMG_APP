using System.Text;
namespace img_app;

class ImageP5_PGM : Image
{
    RGB_Pixel pixel = new();
    private string _name = "image.pgm";

    public new string Name
    {
        get => _name;
        set => _name = value + ".pgm";
    }

    public void CreateRandomFile(int width, int height)
    {
        StringBuilder sb = new("P5\n");
        int len = width * height;
        byte[] pixelArray = new byte[len];

        sb.Append($"{width} {height}\n255\n");
        Write(sb.ToString(), Name);

        byte[] byteArray = new UTF8Encoding(true).GetBytes(sb.ToString());

        pixel.NextBytes(pixelArray);
        BinWrite(ref pixelArray, Name);
        BinWrite(ref byteArray, Name);
    }

}