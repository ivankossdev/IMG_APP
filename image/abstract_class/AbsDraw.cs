namespace img_app;

public abstract class AbsDraw : IDraw
{
    protected string? name;
    protected byte[]? data;
    public abstract void XLines(uint Lenght);
    public abstract void YLines(uint Lenght);
    public abstract void AngleLine();
}