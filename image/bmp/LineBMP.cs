namespace img_app;

public class LineBMP
{
    private byte[] data;
    public readonly uint w;
    public readonly uint h;
    private InfoBMP infoBMP;
    DataInsertsBMP dataInsertsBMP = new();

    public LineBMP(ref byte[] _data)
    {
        data = _data;
        w = dataInsertsBMP.GetData(ref data, 18, 21);
        h = dataInsertsBMP.GetData(ref data, 22, 25);
        infoBMP = new(w);
    }
    public void AddXLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > w) Length = w;
        for (uint x = xPos; x < Length + xPos; x++)
            dataInsertsBMP.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, x, yPos);
    }
    public void AddYLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > h) Length = h;
        for (uint y = yPos; y < Length; y++)
            dataInsertsBMP.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, xPos, y);
    }
}