namespace img_app;

public class Draw : AbsDraw
{
    readonly ShapeBMP serviceBMP;
    readonly RgbPixel rGB_Pixel = new();

    public Draw(string Name)
    {

        name = Name; 
        data = File.Read(name);
        serviceBMP = new(ref data);

    }
    public override void XLines(uint Lenght)
    {
        for (uint i = 0; i < serviceBMP.h; i++)
        {
            serviceBMP.AddXLine(rGB_Pixel.PixelByte(), 0, i, Lenght);
        }
        if(data != null && name != null)
            File.BinWrite(ref data, File.RenameFile(name, $"XLine_{Lenght}"));
    }
    public override void YLines(uint Lenght)
    {
        for (uint i = 0; i < serviceBMP.w; i += 2)
            serviceBMP.AddYLine(rGB_Pixel.PixelByte(), i, 0, Lenght);
        if(data != null && name != null)
            File.BinWrite(ref data, File.RenameFile(name, $"YLines_{Lenght}"));
    }
    public override void AngleLine()
    {
        double angle = MathEx.GetAngle(serviceBMP.w, serviceBMP.h);
        double radian = Math.Tan(Math.PI * angle / 180.0);

        for (uint i = 0; i < serviceBMP.w; i++)
        {
            serviceBMP.AddYLine(rGB_Pixel.PixelByte(), i, 0, (uint)Math.Round(Math.Abs(i * radian)));
        }
        if(data != null && name != null)
            File.BinWrite(ref data, File.RenameFile(name, $"AngleLine"));
    }

    public void AngleLine(double angle)
    {
        double radian = Math.Tan(Math.PI * angle / 180.0);

        for (uint i = 0; i < serviceBMP.w; i++)
        {
            serviceBMP.AddYLine(rGB_Pixel.PixelByte(), i, 0, (uint)Math.Round(Math.Abs(i * radian)));
        }
        if(data != null && name != null)
            File.BinWrite(ref data, File.RenameFile(name, $"AngleLine {angle}"));
    }
}