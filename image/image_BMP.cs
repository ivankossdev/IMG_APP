using System.Text;
namespace img_app;

class Image_BMP : Image
{
    private string _name = "image.bmp";

    public new string Name
    {
        get => _name;
        set => _name = value + ".bmp";
    }

    public void CreateBMP(int width, int height)
    {
        byte[] res = Header(width, height);
        System.Console.WriteLine(FormatOut(ref res));
    }

    private byte[] Header(int width, int height)
    {
        int len = width * height * 4;

        byte[] header = new byte[14];

        header[0] = 0x42;
        header[1] = 0x4d;
        header[10] = 0x36;

        for (int i = 2; i < 6; i++)
        {
            header[i] = 0xff;
        }

        return header;
    }

    private StringBuilder Info()
    {
        StringBuilder info = new();
        return info;
    }
    
    private string FormatOut(ref byte[] buffer)
    {

        int counter = 0;
        StringBuilder sb_hex = new();

        foreach (byte b in buffer)
        {
            sb_hex.AppendFormat("{0:X2} ", b);
            counter++;
            if (counter >= 16)
            {
                counter = 0;
                sb_hex.Append('\n');
            }
        }
        sb_hex.Append('\n');
        return sb_hex.ToString();
    }
}

