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

        using (FileStream fs = new FileStream(Name, FileMode.CreateNew))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                foreach (byte bt in byteArray)
                {
                    w.Write(bt);
                }

                foreach (byte bt in pixelArray)
                {
                    w.Write(bt);
                }
            }
        }
    }

    public static void Read()
    {
        StringBuilder sb = new();

        using (FileStream fstream = File.OpenRead($"{Directory.GetCurrentDirectory()}/image_.pgm"))
        {
            byte[] buffer = new byte[fstream.Length];

            fstream.Read(buffer, 0, buffer.Length);
            Console.WriteLine();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (i <= 10)
                {
                    sb.Append(Convert.ToChar(buffer[i]));
                }

                else if (i > 10 && i < buffer.Length)
                {
                    System.Console.WriteLine($"[{i}] {buffer[i]} {Convert.ToChar(buffer[i])}");
                }
            }
            System.Console.WriteLine(sb.ToString());
        }
    }

}