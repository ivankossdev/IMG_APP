namespace img_app;

interface IDataInserts
{
    public void InsertWord();
    public void InsertPixel();
    public void InsertData(uint data, ref byte[] array, int startPosition, int stopPosition);
    public uint GetData(ref byte[] array, int startPosition, int stopPosition);
}