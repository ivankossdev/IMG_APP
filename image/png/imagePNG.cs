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
        // 0x89 0x50 0x4e 0x47 0x0d 0x0a 0x1a 0x0a заголовок файла 
        byte[] array = new byte[100];
        return array;
    }
        private byte[] Body(ref byte[] array)
    {
        byte[] _array = new byte[100];

        return _array;
    }
}