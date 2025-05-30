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
        byte[] body = Body(ref res);
        BinWrite(ref body, Name);
    }

    private byte[] HeaderFile(int width, int height)
    {
        AppendBytes = width % 4;
        int sizeArray = (width * height * 3) + (height * AppendBytes);

        byte[] array = new byte[54];

        array[0] = 0x42; array[1] = 0x4d; array[10] = 0x36;
        array[14] = 0x28; array[26] = 0x01; array[28] = 0x18;

        int sizeFile = sizeArray + array[10];

        // Размер файла
        InsertData((uint)sizeFile, ref array, 2, 5);
        // Ширина изображения
        InsertData((uint)width, ref array, 18, 21);
        // Высота изображения
        InsertData((uint)height, ref array, 22, 25);
        // Размер массива
        InsertData((uint)sizeArray, ref array, 34, 37);
        // Разрешение на пиксель по горизотали и вертикали 41115
        InsertData(0xAC3, ref array, 38, 41);
        InsertData(0xAC3, ref array, 42, 45);

        return array;
    }

    private byte[] Body(ref byte[] array)
    {
        uint len = GetData(ref array, 34, 37) + (uint)array.Length;
        uint lenWord = GetData(ref array, 18, 21) * 3 + (uint)AppendBytes;
        uint h = GetData(ref array, 22, 25);
        byte[] _array = new byte[len];

        for (int i = 0; i < 54; i++)
            _array[i] = array[i];

        for (uint c = 0; c < h; c++)
            InsertWord(ref _array, lenWord, c, 0xff, 0xff, 0xff);

        return _array;
    }

    private void InsertWord(ref byte[] array, uint lenWord, uint c, byte blue, byte green, byte red )
    {
        uint _lenWord = lenWord - (uint)AppendBytes + 54;
        c = lenWord * c;

        for (uint i = 54 + c; i < _lenWord + c; i += 3)
        {
            array[i] = blue; 
            array[i + 1] = green;
            array[i + 2] = red;
        }
    }

    private static void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            array[i] = (byte)((size >> (8 * i_)) & 0xff);
        }
    }

    private static uint GetData(ref byte[] array, int startPosition, int stopPosition)
    {
        uint data = 0;
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            data |= (uint)array[i] << (8 * i_);
        }

        return data;
    }
}