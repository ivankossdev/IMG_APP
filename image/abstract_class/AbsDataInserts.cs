namespace img_app;

public abstract class AbsDataInserts : IDataInserts
{
    public abstract void InsertWord();
    public abstract void InsertPixel();
    public void InsertData()
    {
        throw new NotImplementedException();
    }
    public void InsertData(uint size, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            array[i] = (byte)((size >> (8 * i_)) & 0xff);
        }
    }

}