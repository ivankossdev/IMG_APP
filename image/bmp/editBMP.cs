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

    public void FillRandLines()
    {
        RGB_Pixel rgb_Pixel = new();
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
    }
}