using System.Text;
namespace img_app;

class ImagePBM(string fileName){
    public string Name { get; } = $"{fileName}.pbm";
    public string Path() => $"{Directory.GetCurrentDirectory()}/{Name}";

    public void Create(int width, int height){
        StringBuilder sb = new ("P1\n");
        sb.Append($"{width} {height}\n");

        for(int i = 0; i < height; i++){
            sb.Append($"{RandValue(width)}\n");
        }

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

    private string RandValue(int count){
        Random rnd = new();
        StringBuilder randString = new();

        for(int i = 0; i < count; i++){
            randString.Append($"{rnd.Next(0, 2)} ");
        }

        return randString.ToString();
    }
}