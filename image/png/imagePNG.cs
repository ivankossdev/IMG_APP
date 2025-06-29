using System.Text;
namespace img_app;

public class ImagePNG
{
    private string _name = "image.png";
    readonly File file = new();
    public string Name
    {
        get => _name;
        set => _name = value + ".png";
    }
    public void Create(int width, int height)
    {
        byte[] res = HeaderFile(width, height);
        byte[] body = Body(ref res);
        file.BinWrite(ref body, Name);
    }
    private byte[] HeaderFile(int width, int height)
    {
        byte[] array = new byte[100];

        // 0x89 0x50 0x4e 0x47 0x0d 0x0a 0x1a 0x0a заголовок файла png  
        array[0] = 0x89; array[1] = 0x50; array[2] = 0x4e; array[3] = 0x47;
        array[4] = 0x0d; array[5] = 0x0a; array[6] = 0x1a; array[7] = 0x0a;

        Length(ref array);
        Type(ref array);

        return array;
    }
    private void Length(ref byte[] array)
    {
        // Размер Body
        for (int i = 8; i < 12; i++)
        {
            array[i] = 0x00;
        }
    }
    private void Type(ref byte[] array)
    {
        // IDAT
        byte[] byteArray = new UTF8Encoding(true).GetBytes("IDAT");

        for (int i = 12, i_ = 0; i < 15; i++, i_++)
        {
            array[i] = byteArray[i_];
        }
    }

    private byte[] Body(ref byte[] array)
    {
        byte[] _array = new byte[100];

        return _array;
    }
}