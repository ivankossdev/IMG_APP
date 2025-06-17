namespace img_app;

public class EditBMP
{
    private byte[] data;
    public readonly uint w;
    public readonly uint h;
    private InfoBMP infoBMP;
    public EditBMP(ref byte[] _data)
    {
        data = _data;
        w = Image.GetData(ref data, 18, 21);
        h = Image.GetData(ref data, 22, 25);
        infoBMP = new(w);
    }
    readonly RGB_Pixel rgb_Pixel = new();

    public void AddXLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > h) Length = h;
        for (uint x = xPos; x < Length + xPos; x++)
            Image.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, x, yPos);
    }
    public void AddYLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > w) Length = w;
        for (uint y = yPos; y < Length; y++)
            Image.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, xPos, y);
    }
    public void AddRandomPixels()
    {
        Random random = new();

        for (uint i = 0; i < h; i++)
        {
            for (uint _i = 0; _i < w; _i++)
                Image.InsertPixel(ref data, rgb_Pixel.PixelByte(), infoBMP.LenghtWord,
                                 (uint)random.Next(0, (int)w), (uint)random.Next(0, (int)i));
        }
    }
}