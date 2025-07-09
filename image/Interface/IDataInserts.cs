namespace img_app;

interface IDataInserts
{
    public void InsertWord();
    public void InsertPixel();
    public void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition);
}