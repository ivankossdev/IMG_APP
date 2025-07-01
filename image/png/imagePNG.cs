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

        SetLenghtChunk(ref array, 13);
        SetWidthImage(ref array, 640);
        SetHeightImage(ref array, 480);
        Type(ref array);

        return array;
    }
    private void SetLenghtChunk(ref byte[] array, int l)
    {
        // Длина array[8 ... 11]
        array[11] = (byte)l;
        for (int i = 0, i_ = 11; i < 4; i++, i_--)
        {
            System.Console.WriteLine($"{i} {i_}");
        }
    }
    private void Type(ref byte[] array)
    {
        // IHDR Заголовок изображения 0x49, 0x48, 0x44, 0x52
        byte[] byteArray = new UTF8Encoding(true).GetBytes("IHDR");

        for (int i = 12, i_ = 0; i < 15; i++, i_++)
        {
            array[i] = byteArray[i_];
        }
    }
    private void SetWidthImage(ref byte[] array, int w)
    {
        // 4 byte array[16 ... 19] 
    }
    private void SetHeightImage(ref byte[] array, int w)
    {
        // 4 byte array[20 ... 23]
    }
    private byte[] Body(ref byte[] array)
    {
        byte[] _array = new byte[100];

        return _array;
    }
}