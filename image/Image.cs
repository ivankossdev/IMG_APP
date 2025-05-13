using System.Text;
namespace img_app;

public class Image
{
    private string _name = "image";
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool CheckFolder(){
        foreach(string s in Directory.GetDirectories(Directory.GetCurrentDirectory())){
            if(s == $"{Directory.GetCurrentDirectory()}/example") return true;
        }
        return false;
    }

    public string Path(string name)
    {
        if(CheckFolder()) System.Console.WriteLine("Folder is found");
        else Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/example/");
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

    protected void BinWrite(ref byte[] data,string name){
        
        using (FileStream fs = new FileStream(Path(name), FileMode.Append))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                foreach (byte bt in data)
                {
                    w.Write(bt);
                }
            }
        }
    }
}