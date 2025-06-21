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
        for (uint i = 0; i < serviceBMP.w; i += 2)
            serviceBMP.AddYLine(rGB_Pixel.PixelByte(), i, 0, Lenght);

        BinWrite(ref data, RenameFile(name, $"YLines_{Lenght}"));
    }
    public void AngleLine()
    {
        double angle = MathEx.GetAngle(serviceBMP.w, serviceBMP.h);
        double radian = Math.Tan(Math.PI * angle / 180.0);       

        for (uint i = 0; i < serviceBMP.w; i++)
        {
            serviceBMP.AddYLine(rGB_Pixel.PixelByte(), i, 0, (uint)Math.Round(Math.Abs(i * radian)));
        }

        BinWrite(ref data, RenameFile(name, $"AngleLine")); 
    }
}