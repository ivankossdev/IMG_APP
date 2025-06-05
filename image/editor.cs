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

                InfoBMP infoBMP = new(w);
                Random random = new();

                Image.InsertWord(ref data, infoBMP.LenghtWord, 0, infoBMP.AppBytes, [ 0x00, 0x00, 0xff ]);
                RGB_Pixel rgb_Pixel = new();

                for (int i = 0; i < 10; i++)
                {
                    Image.InsertWord(ref data, infoBMP.LenghtWord, (uint)random.Next(0, (int)h - 2), infoBMP.AppBytes, rgb_Pixel.PixelByte());
                }

                Image.InsertWord(ref data, infoBMP.LenghtWord, h - 1, infoBMP.AppBytes, [ 0x00, 0xff, 0x00 ]);
                
                BinWrite(ref data, RenameFile(Name, "Rand"));
                break;
            default:
                System.Console.WriteLine(fileType);
                break;
        }
    }
}