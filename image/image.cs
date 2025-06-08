namespace img_app;

class Image
{
    public static void InsertWord(ref byte[] array, uint lenWord, uint c, uint appendBytes, byte[] pixel)
    {
        uint _lenWord = lenWord - appendBytes + 54;
        c = lenWord * c;

        for (uint i = 54 + c; i < _lenWord + c; i += 3)
        {
            array[i] = pixel[0];     // blue
            array[i + 1] = pixel[1]; // green
            array[i + 2] = pixel[2]; // red
        }
    }
    public static void InsertPixel(ref byte[] array, byte[] pixel, uint lenWord, uint xPos, uint yPos)
    {
        xPos += 54 + xPos * 2;
        uint pixelPos = xPos + lenWord * yPos;

        array[pixelPos] = pixel[0];     // blue
        array[pixelPos + 1] = pixel[1]; // green
        array[pixelPos + 2] = pixel[2]; // red
    }

    public static void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            array[i] = (byte)((size >> (8 * i_)) & 0xff);
        }
    }

    public static uint GetData(ref byte[] array, int startPosition, int stopPosition)
    {
        uint data = 0;
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            data |= (uint)array[i] << (8 * i_);
        }

        return data;
    }

}