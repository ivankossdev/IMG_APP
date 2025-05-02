
using System.Text;
using System.IO;

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        createFile("test.pbm");
    }

    static void createFile(string fileName){
       string path = $"{Directory.GetCurrentDirectory()}/{fileName}";
        try
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("P1\n4 4\n1111\n1001\n1001\n1111\n");
                fs.Write(info, 0, info.Length);
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
