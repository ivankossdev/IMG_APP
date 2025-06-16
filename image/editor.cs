using System.Text;
namespace img_app;

public class Editor : File
{
    protected string GetFileType()
    {
        string[] str = Name.Split('.');
        return str.Length > 0 ? str[^1] : $"File not found type";
    }

    public void AddLineXCord()
    {
        string fileType = GetFileType();
        switch (fileType)
        {
            case "bmp":
                byte[] data = Read(Name);
                EditBMP editBMP = new(ref data);
                editBMP.FillLinesXCord();
                editBMP.FillLinesYCord();
                BinWrite(ref data, RenameFile(Name, "Rand"));

                editBMP.AddRandomPixels();
                for (uint y = 2; y <= 100; y++) {
                    editBMP.AddYLine([0x00, 0x00, 0xff], y, y, 100);
                }
                editBMP.AddXLine([0x00, 0x00, 0xff], 2, 2, 100);
                editBMP.AddYLine([0x00, 0x00, 0xff], 100, 2, 100);
                BinWrite(ref data, RenameFile(Name, "Rand_1"));
                break;
            default:
                Console.WriteLine(fileType);
                break;
        }
    }
}