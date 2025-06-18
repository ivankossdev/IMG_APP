namespace img_app;

public class Add : File
{
    private readonly string name;
    private byte[] data;
    readonly ServiceBMP serviceBMP;
    readonly RGB_Pixel rGB_Pixel = new();

    public Add(string Name)
    {
        name = Name;
        data = Read(name);
        serviceBMP = new(ref data);

    }
    public void XLines(uint Lenght)
    {
        for (uint i = 0; i < serviceBMP.h; i++)
        {
            serviceBMP.AddXLine(rGB_Pixel.PixelByte(), 0, i, Lenght);
        }

        BinWrite(ref data, RenameFile(name, $"XLine_{Lenght}"));
    }
    public void YLines(uint Lenght)
    {
        for (uint i = 0; i < serviceBMP.h; i++)
        {
            serviceBMP.AddYLine([0x00, 0x00, 0xff], serviceBMP.w / 2, i, Lenght);
        }

        BinWrite(ref data, RenameFile(name, $"YLines_{Lenght}"));
    }
}