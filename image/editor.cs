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

                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 0);
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 1, 0);
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 2, 0);
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 1);
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 1, 1);
                Image.InsertPixel(ref data, [0xff, 0x00, 0x00], infoBMP.LenghtWord, 0, 2);
                
                BinWrite(ref data, RenameFile(Name, "Rand"));
                break;
            default:
                Console.WriteLine(fileType);
                break;
        }
    }
}