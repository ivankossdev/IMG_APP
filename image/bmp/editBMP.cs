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
    public void FillRandLines()
    {
        for (int i = 0; i < h; i++)
        {
            Image.InsertWord(ref data, infoBMP.LenghtWord, (uint)i, infoBMP.AppBytes, rgb_Pixel.PixelByte());
        }
    }

    public void AddPixels()
    {
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 0);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 1, 0);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 2, 0);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 1);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 1, 1);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 2);
        Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 2);
    }

    public void AddRandomPixels()
    {
        Random random = new();

        for (uint i = 0; i < h; i++)
        {
            for(uint _i = 0; _i < w - 1; _i++)
                Image.InsertPixel(ref data, rgb_Pixel.PixelByte(), infoBMP.LenghtWord, (uint)random.Next(0, (int)w - 1) ,
                                  (uint)random.Next(0, (int)i));
        }
    }
}