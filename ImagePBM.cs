using System.Text;
namespace img_app;

class ImagePBM(string fileName){
    public string Name { get; } = $"{fileName}.pbm";
    public string Path() => $"{Directory.GetCurrentDirectory()}/{Name}";

    public void Create(int height, int width, string str){
        StringBuilder sb = new ("P1\n");
        sb.Append($"{height} {width}\n");
        sb.Append(str);
        Write(sb.ToString());
    }

    private void Write(string data){
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