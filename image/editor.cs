using System.Text;
namespace img_app;

public class Editor : File
{
    protected string GetFileType()
    {
        string[] str = Name.Split('.');
        return str.Length > 0 ? str[^1] : $"File not found type";
    }

    public void AddLine()
    {
        string fileType = GetFileType();
        switch (fileType)
        {
            case "bmp":
                byte[] data = Read(Name);
                uint w = Image.GetData(ref data, 18, 21);
                uint h = Image.GetData(ref data, 22, 25);
                uint appendBytes = w % 4;
                uint lenWord = w * 3 + appendBytes;
                Random random = new();

                Image.InsertWord(ref data, lenWord, 0, appendBytes, 0x00, 0x00, 0xff);

                for (int i = 0; i < 10; i++)
                    Image.InsertWord(ref data, lenWord, (uint)random.Next(0, (int)h - 2), appendBytes, 0xff, 0x00, 0x00);

                Image.InsertWord(ref data, lenWord, h - 1, appendBytes, 0x00, 0xff, 0x00);
                
                BinWrite(ref data, RenameFile(Name, "Rand"));
                break;
            default:
                System.Console.WriteLine(fileType);
                break;
        }
    }
}