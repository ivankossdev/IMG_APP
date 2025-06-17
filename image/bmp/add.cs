namespace img_app;

public class Add : File
{
    private readonly string name;
    private byte[] data;
    readonly ServiceBMP editBMP;
    readonly RGB_Pixel rGB_Pixel = new();

    public Add(string Name)
    {
        name = Name;
        data = Read(name);
        editBMP = new(ref data);

    }
    public void Lines(uint Lenght)
    {
        for (uint i = 0; i < editBMP.h; i++)
        {
            editBMP.AddXLine(rGB_Pixel.PixelByte(), Lenght * 0, i, Lenght);
            editBMP.AddXLine([50, 127, 50], Lenght * 1, i, Lenght);
            editBMP.AddXLine([0xff, 0x00, 0x00], Lenght * 2, i, Lenght);
        }

        BinWrite(ref data, RenameFile(name, $"Line_{Lenght}"));
    }
}