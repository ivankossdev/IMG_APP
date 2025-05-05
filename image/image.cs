using System.Text;
namespace img_app;

public class Image(string fileName){
    public string Name { get; } = $"{fileName}.pbm";
    public string Path() => $"{Directory.GetCurrentDirectory()}/{Name}";
    protected void Write(string data){
        try
        {
            using FileStream fs = File.Create(Path());
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            fs.Write(info, 0, info.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}