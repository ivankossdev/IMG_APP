namespace img_app;

public abstract class DataInserts : IDataInserts
{
    public abstract void InsertWord();
    public abstract void InsertPixel();
    public void InsertData() { }
}