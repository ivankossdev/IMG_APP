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
        Console.WriteLine("{0}\n", _path);
        try{
            using (FileStream fstream = File.OpenRead(_path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string res = FormatOut(ref buffer);
                Console.WriteLine(res);
            }
        }
        catch (FileNotFoundException){
            Console.WriteLine("File not found");
        }
    }

    private static string FormatOut(ref byte[] buffer){

        int counter = 0;
        StringBuilder sb = new();

        foreach(byte b in buffer){
            sb.AppendFormat("{0:X2} ", b);
            counter++;
            if (counter >= 16) {
                counter = 0;
                sb.Append('\n');
            }            
        }
        sb.Append('\n');
        return sb.ToString();
    }
}