using System.Text;
namespace img_app;

public class GetFileInfo{

    private string _name = string.Empty;
    private string _path => $"{Directory.GetCurrentDirectory()}/{Name}";
    
    public string Name{
        get => _name;
        set => _name = value; 
    }

    public void GetAllByte(){
        Console.WriteLine($"{_path}");
        try{
            using (FileStream fstream = System.IO.File.OpenRead(_path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string res = FormatOut(ref buffer);
                WriteRes(res);
            }
        }
        catch (FileNotFoundException){
            Console.WriteLine("File not found");
        }
    }

    private static string FormatOut(ref byte[] buffer){

        int counter = 0;
        StringBuilder sb_hex = new();

        foreach(byte b in buffer){
            sb_hex.AppendFormat("{0:X2} ", b);
            counter++;
            if (counter >= 16) {
                counter = 0;
                sb_hex.Append('\n');
            }            
        }
        sb_hex.Append('\n');
        return sb_hex.ToString();
    }

    protected void WriteRes(string data)
    {
        try
        {
            using FileStream fs = System.IO.File.Create(_path.Replace("bmp", "txt"));
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            fs.Write(info, 0, info.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}