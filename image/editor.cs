namespace img_app;

public class Editor : File
{
    protected string GetFileType()
    {
        string[] str = Name.Split('.');
        return str.Length > 0 ? str[^1] : $"File not found type";
    }

    public void CreateRandom()
    {
        string fileType = GetFileType();
        switch (fileType)
        {
            case "bmp":
                byte[] data = Read(Name);
                uint w = Image.GetData(ref data, 18, 21);
                uint appendBytes = w % 4;
                uint lenWord = w * 3 + appendBytes; 
                Image.InsertWord(ref data, lenWord, 1, appendBytes, 0x7f, 0x7f, 0x7f);
                // BinWrite(ref data, Name);
                System.Console.WriteLine($"Detectep bmp {Name} file width {w} {appendBytes} {lenWord}");
                break;

            default:
                System.Console.WriteLine(fileType);
                break;
        }
    }
}