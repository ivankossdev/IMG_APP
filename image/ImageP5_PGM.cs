using System.Text;
namespace img_app;

class ImageP5_PGM : Image
{
    private string _name = "image.ppm";

    public new string Name
    {
        get => _name;
        set => _name = value + ".pgm";
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