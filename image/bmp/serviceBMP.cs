namespace img_app;

public class ServiceBMP
{
    private byte[] data;
    public readonly uint w;
    public readonly uint h;
    private InfoBMP infoBMP;
    public ServiceBMP(ref byte[] _data)
    {
        data = _data;
        w = Image.GetData(ref data, 18, 21);
        h = Image.GetData(ref data, 22, 25);
        infoBMP = new(w);
    }
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
}