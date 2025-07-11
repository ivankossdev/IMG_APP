namespace img_app;

public class DataInsertsPNG : AbsDataInserts
{
    public override void InsertWord()
    {
        throw new NotImplementedException();
    }

    public override void InsertPixel()
    {
        throw new NotImplementedException();
    }
    public override uint GetData(ref byte[] array, int startPosition, int stopPosition)
    {
        throw new NotImplementedException();
    }

    public override void InsertData(uint data, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = stopPosition, i_ = 0; i >= startPosition; i--, i_++)
        {
            array[i] = (byte)((data >> (8 * i_)) & 0xff);
        }
    }
    
    public void InsertData(ref byte[] data, ref byte[] array, int startPosition, int stopPosition)
    {
        for (int i = startPosition, i_ = 0; i <= stopPosition; i++, i_++)
        {
            array[i] = data[i_];
        }
    }
}