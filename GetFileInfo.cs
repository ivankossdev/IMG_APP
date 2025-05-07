namespace img_app;

public class GetFileInfo{

    private string _name = string.Empty;
    private string _path => $"{Directory.GetCurrentDirectory()}/{Name}";
    
    public string Name{
        get => _name;
        set => _name = value; 
    }

    public void GetAllByte(){
        System.Console.WriteLine(_path);
        try{
            using (FileStream fstream = File.OpenRead(_path))
            {
                byte[] buffer = new byte[fstream.Length];

                fstream.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"Len file {buffer.Length} byte. \n");

                for (int i = 14; i < buffer.Length; i++)
                {
                    Console.WriteLine($"[{i}] {buffer[i]}");
                }
            }
        }
        catch (FileNotFoundException){
            Console.WriteLine("File not found");
        }
    }
}