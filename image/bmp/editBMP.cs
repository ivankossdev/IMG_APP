namespace img_app;

public class EditBMP
{
    private byte[] data;
    private readonly uint w;
    private readonly uint h;
    private InfoBMP infoBMP;
    public EditBMP(ref byte[] _data)
    {
        data = _data;
        w = Image.GetData(ref data, 18, 21);
        h = Image.GetData(ref data, 22, 25);
        infoBMP = new(w);
    }
    RGB_Pixel rgb_Pixel = new();
    public void FillLinesXCord()
    {
        for (int i = 0; i < h; i++)
        {
            Image.InsertWord(ref data, infoBMP.LenghtWord, (uint)i, infoBMP.AppBytes, rgb_Pixel.PixelByte());
        }
    }

    public void FillLinesYCord()
    {
        for (uint _w = w / 2; _w < w; _w++)
            for (uint _h = h / 2; _h < h; _h++)
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, _w, _h);
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

    public void AddLine(byte[] Pixel, int Length, int x, int y)
    {
        
    }
}