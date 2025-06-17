namespace img_app;

public class Add(string Name) : File
{
    private readonly string name = Name;
    public void Lines(uint Lenght)
    {
        byte[] data = Read(name);
        ServiceBMP editBMP = new(ref data);
        
        for (uint i = 0; i < editBMP.h; i++)
        {
            editBMP.AddXLine([0x00, 0x00, 0xff], Lenght * 0, i, Lenght);
            editBMP.AddXLine([0xff, 0x00, 0x00], Lenght * 1, i, Lenght);
            editBMP.AddXLine([0x00, 0xff, 0x00], Lenght * 2, i, Lenght);
        }

        BinWrite(ref data, RenameFile(name, $"Line_{Lenght}"));
    }
}