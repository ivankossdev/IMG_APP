namespace img_app;

public abstract class AbsDataInserts : IDataInserts
{
    public abstract void InsertWord();
    public abstract void InsertPixel();
    public abstract void InsertData(uint data, ref byte[] array, int startPosition, int stopPosition);
}