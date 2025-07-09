namespace img_app;

public abstract class AbsDataInserts : IDataInserts
{
    public abstract void InsertWord();
    public abstract void InsertPixel();
    public abstract void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition);
}