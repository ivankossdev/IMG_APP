using System.Text;
namespace img_app;

public class File
{
    private string _name = "image";
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public File()
    {
        if (!CheckFolder()) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/example/");
    }

    protected static string RenameFile(string Name, string add)
    {
        string[] temp = Name.Split('.');
        return $"{temp[0]}_{add}.{temp[1]}";
    }

    public static bool CheckFolder()
    {
        foreach (string s in Directory.GetDirectories(Directory.GetCurrentDirectory()))
        {
            if (s == $"{Directory.GetCurrentDirectory()}/example") return true;
        }
        return false;
    }

    public static bool CheckFolder(string folder)
    {
        foreach (string s in Directory.GetDirectories(Directory.GetCurrentDirectory()))
        {
            if (s == $"{Directory.GetCurrentDirectory()}/{folder}") return true;
        }
        return false;
    }

    public static string Path(string name)
    {
        return $"{Directory.GetCurrentDirectory()}/example/{name}";
    }

    protected static void Write(string data, string name)
    {
        try
        {
            using FileStream fs = System.IO.File.Create(Path(name));
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            fs.Write(info, 0, info.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static void BinWrite(ref byte[] data, string name)
    {
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

    protected static byte[] Read(string name)
    {
        try
        {
            using FileStream file = System.IO.File.Open(Path(name), FileMode.Open);
            byte[] byteArray = new byte[file.Length];
            file.Read(byteArray, 0, byteArray.Length);
            
            return byteArray;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exaption Read func");
            Console.WriteLine(ex);
        }
        return [];
    }

}