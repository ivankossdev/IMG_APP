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
                BinWrite(ref data, RenameFile(Name, "Rand_1"));
                break;
            default:
                Console.WriteLine(fileType);
                break;
        }
    }


}