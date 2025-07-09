namespace img_app;

public class LineBMP
{
    private byte[] data;
    public readonly uint w;
    public readonly uint h;
    private InfoBMP infoBMP;
    public LineBMP(ref byte[] _data)
    {
        data = _data;
        w = DataInsertsBMP.GetData(ref data, 18, 21);
        h = DataInsertsBMP.GetData(ref data, 22, 25);
        infoBMP = new(w);
    }
    public void AddXLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > w) Length = w;
        for (uint x = xPos; x < Length + xPos; x++)
            DataInsertsBMP.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, x, yPos);
    }
    public void AddYLine(byte[] Pixel, uint xPos, uint yPos, uint Length)
    {
        if (Length > h) Length = h;
        for (uint y = yPos; y < Length; y++)
            DataInsertsBMP.InsertPixel(ref data, Pixel, infoBMP.LenghtWord, xPos, y);
    }
}