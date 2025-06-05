namespace img_app;

struct InfoBMP(uint _Width)
{
    public uint Width = _Width;
    public readonly uint AppBytes => Width % 4;
    public readonly uint LenghtWord => Width * 3 + AppBytes;
}