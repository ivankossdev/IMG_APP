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
                System.Console.WriteLine($"Detectep bmp {Name} file width {Image.GetData(ref data, 18, 21)}");
                break;

            default:
                System.Console.WriteLine(fileType);
                break;
        }
    }
}