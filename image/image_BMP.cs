using System.Text;
namespace img_app;

class Image_BMP : Image
{
    private string _name = "image.bmp";
    private int AppendBytes = 0;

    public new string Name
    {
        get => _name;
        set => _name = value + ".bmp";
    }

    public void CreateBMP(int width, int height)
    {
        byte[] res = HeaderFile(width, height);
        System.Console.WriteLine(FormatOut(ref res));
    }

    private byte[] HeaderFile(int width, int height)
    {
        AppendBytes = width % 4;
        int sizeArray = (width * height * 3) + (height * AppendBytes);

        byte[] array = new byte[54];

        array[0] = 0x42;  array[1] = 0x4d;  array[10] = 0x36;
        array[14] = 0x28; array[26] = 0x01; array[28] = 0x18;

        int sizeFile = sizeArray + array[10];

        // Размер файла
        InsertData((uint)sizeFile, ref array, 2, 5);
        // Размер массива
        InsertData((uint)sizeArray, ref array, 34, 38);
        System.Console.WriteLine("size array {0:X2}", sizeArray);
        return array;
    }

    private static void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = startPosition, i_ = 0; i <+ stopPosition; i++, i_++)
        {
            array[i] = (byte)((size >> (8 * i_)) & 0xff);
        }
    }
    
    private static string FormatOut(ref byte[] buffer)
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

        return sb_hex.ToString();
    }
}

