using System.Text;
namespace img_app;

public class Image
{
    private string _name = "image";
    public string Name {
        get => _name;
        set => _name = value;
    }

    public string Path(string name)
    {
        return $"{Directory.GetCurrentDirectory()}/example/{name}";
    }

    protected void Write(string data, string name)
    {
        try
        {
            using FileStream fs = File.Create(Path(name));
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            fs.Write(info, 0, info.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}