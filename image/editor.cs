using System.Text;
namespace img_app;

public class Editor : File
{
    readonly RGB_Pixel rgb_Pixel = new();
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

                InfoBMP infoBMP = new(w);

                for (int i = 0; i < h - 1; i++)
                {
                    Image.InsertWord(ref data, infoBMP.LenghtWord, (uint)i, infoBMP.AppBytes, rgb_Pixel.PixelByte());
                }
                
                BinWrite(ref data, RenameFile(Name, "Rand"));
                break;
            default:
                Console.WriteLine(fileType);
                break;
        }
    }
}