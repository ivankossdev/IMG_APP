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
                System.Console.WriteLine("Detectep bmp file");
                break;

            default:
                System.Console.WriteLine(fileType);
                break;
        }
    }
}